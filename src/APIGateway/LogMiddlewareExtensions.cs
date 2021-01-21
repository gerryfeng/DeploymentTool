using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway
{
    public static class LogMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogWare(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentException("app");
            return UseMiddlewareExtensions.UseMiddleware<LogMiddleware>(app);
        }
    }

    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private Stopwatch _stopwatch;

        public LogMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
            _stopwatch = new Stopwatch();
        }

        public async Task Invoke(HttpContext context)
        {
             _stopwatch.Restart();
            string requesturl = "";

            try
            {
                string remoteIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
               
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
                    if(obj != null) 
                    {
                        if (obj.code == 0)
                            msg = "";
                        else
                            msg = obj.msg;
                    }
                    
                }
                else
                {
                    Status obj = JsonConvert.DeserializeObject<Status>(msg);

                    if(obj != null)
                    {
                        if (obj.statusCode != "0000")
                            msg = obj.errMsg;
                        else
                            msg = "";
                    }
                }

                //context.Request.Headers["X-Forwarded-For"].FirstOrDefault()
                //context.Request.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()
                string sql = @$"INSERT INTO CallLog( UserIp, DownstreamRequest, Path, Method, QueryString, RequestBodyLength, CallTime,  Result,ConsumerTime,ResponseSize,ErrorMsg) VALUES (
                    '{remoteIp}','{requesturl}','{context.Request.Path}', '{context.Request.Method}', '{context.Request.QueryString}', '{context.Request.ContentLength}', '{DateTime.Now.ToString("s")}',
                   '{context.Response.StatusCode}', '{_stopwatch.ElapsedMilliseconds}','{context.Response.ContentLength}','{msg}');";
                SqliteHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
               // await _next(context);
                // Logger.LogDebug(ex.Message);
            }

        }
    }
}
