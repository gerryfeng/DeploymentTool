using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Web.DTO;

namespace Web.ExceptionFilter
{
    public class CustomerExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                Results<object> results = new Results<object>();
                string msg = context.Exception.Message;
                results.say.statusCode = "001";
                results.say.errMsg = msg;
                context.Result = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(results),
                    StatusCode = StatusCodes.Status200OK,
                    ContentType = "application/json;charset=utf-8"
                };
            }
            context.ExceptionHandled = true; //异常已处理了

            return Task.CompletedTask;
        }
    }
}
