using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OMS.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Web.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                context.Result = new JsonResult(new ResponseBase<string>()
                {
                    code=-1,
                    msg = context.Exception.Message
                });
            }
            context.ExceptionHandled = true;
        }
    }
}
