using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using OMS.ApplicationCore;
using System;

namespace OMS.Web
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<GlobalExceptionFilter> _logger;
        private readonly ICallLogRepository _sqliteLogService;
        public GlobalExceptionFilter(IWebHostEnvironment env, ILogger<GlobalExceptionFilter> logger, ICallLogRepository sqliteLogService)
        {
            _env = env;
            _logger = logger;
            _sqliteLogService = sqliteLogService;
        }
        public void OnException(ExceptionContext context)
        {
            ResponseBase<string> result = new ResponseBase<string>();
            result.SetError(context.Exception.StackTrace);

            context.Result = new JsonResult(result);
            _logger.LogError(context.Exception, context.Exception.Message);
            context.ExceptionHandled = true;
        }
    }


    /// <summary>
    /// 自定义业务异常类
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException() { }
        public BusinessException(string message) : base(message)
        { }
        public BusinessException(string message, Exception innerException) : base(message, innerException)
        { }
    }

    /// <summary>
    /// 自定义内部错误响应结果
    /// </summary>
    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
    
    /// <summary>
    /// 自定义响应结果模型
    /// </summary>
    public class JsonErrorReponse
    {
        public string Message { get; set; }
        public string DeveloperMessage { get; set; }
    }
}
