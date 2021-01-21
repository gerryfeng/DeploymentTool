using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OMS.ApplicationCore;
using OMS.Infrastructure;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OMS.Web
{
    public class ApiLogFilter : IAsyncActionFilter
    {
        private readonly ILogger logger;
        private readonly ICallLogRepository _sqliteLogService;
        
        Stopwatch stopwatch;

        public ApiLogFilter(ILogger<ApiLogFilter> logger, ICallLogRepository sqliteLogService)
        {
            this.logger = logger;
            _sqliteLogService = sqliteLogService;
           
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            stopwatch = new Stopwatch();
            stopwatch.Start();
            var resultContext = await next();

            stopwatch.Stop();
            dynamic result = resultContext.Result.GetType().Name == "EmptyResult" ? new { Value = new ResponseBase<string>() { code =-1, msg = "EmptyResult" } } : resultContext.Result as dynamic;

            var response = result.Value;
            //await _sqliteLogService.AddCallLogAsync(new CallLog()
            //{
            //    IP = resultContext.HttpContext.Request.Host.ToString(),
            //    Path = resultContext.HttpContext.Request.Path.ToString(),
            //    Method = resultContext.HttpContext.Request.Method,
            //    QueryString = resultContext.HttpContext.Request.QueryString.ToString(),
            //    Body = JsonConvert.SerializeObject(context.ActionArguments),
            //    Result = response.code,
            //    CallTime = DateTime.Now,
            //    ConsumerTime = stopwatch.ElapsedMilliseconds,
            //    ResponseSize = JsonConvert.SerializeObject(response).Length,
            //    ErrorMsg = response.msg
            //}) ;
        }
    }
}
