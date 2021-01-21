using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ocelot.Logging;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGateway
{
    public class OcelotMiddlewareExtensions : OcelotMiddleware
    {
        
        private readonly RequestDelegate _next;
        private readonly Stopwatch _stopwatch;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OcelotMiddlewareExtensions(RequestDelegate next,
            IOcelotLoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor) : base(loggerFactory.CreateLogger<OcelotMiddlewareExtensions>())
        {
            _stopwatch = new Stopwatch();
            _next = next;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Invoke(HttpContext context)
        {
             _stopwatch.Restart();
            string requesturl = "";

            try
            {
                string remoteIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                //context.Request.EnableBuffering();
                //var requestReader = new StreamReader(context.Request.Body);
                //string requestBody = await requestReader.ReadToEndAsync();
                //context.Request.Body.Position = 0;

                var originalResponseStream = context.Response.Body;

                string result = "";
                using (MemoryStream ms = new MemoryStream())
                {
                    context.Response.Body = ms;

                    await _next(context);
                    _stopwatch.Stop();

                    requesturl = context.Items.ContainsKey("DownstreamRequest") ? context.Items["DownstreamRequest"].ToString() : "";
                    if (requesturl == "") return;

                    ms.Position = 0;
                    result = await new StreamReader(ms).ReadToEndAsync();
                    ms.Position = 0;

                    await ms.CopyToAsync(originalResponseStream);
                    context.Response.Body = originalResponseStream;
                }

                string msg = result;
                if (requesturl.Contains("OMS"))
                {
                    ResponseBase obj = JsonConvert.DeserializeObject<ResponseBase>(msg);
                    if (obj.code == 0)
                        msg = "";
                    else
                        msg = obj.msg;
                }
                else
                {
                    Status obj = JsonConvert.DeserializeObject<Status>(msg);
                    if (obj.statusCode != "0000")
                        msg = obj.errMsg;
                    else
                        msg = "";
                }

                //string remoteIp = context.Connection.RemoteIpAddress.ToString();
               
                
                string sql = @$"INSERT INTO CallLog( UserIp, DownstreamRequest, Path, Method, QueryString, RequestBodyLength, CallTime,  Result,ConsumerTime,ResponseSize,ErrorMsg) VALUES (
                    '{remoteIp}','{requesturl}','{context.Request.Path}', '{context.Request.Method}', '{context.Request.QueryString}', '{context.Request.ContentLength}', '{DateTime.Now}',
                   '{context.Response.StatusCode}', '{_stopwatch.ElapsedMilliseconds}','{context.Response.ContentLength}','{msg}');";
                SqliteHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex.Message);
            }
           
        }
    }


    
    public static class DownstreamContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseDownstreamContextMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OcelotMiddlewareExtensions>();
        }
    }
}
