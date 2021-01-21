using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OMS.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Web.Filters
{
    public class GlobalActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                return;
            }
            var result = context.Result as ObjectResult ;
            context.Result =result==null ? new JsonResult(new ResponseBase<string>(null)): new JsonResult(new ResponseBase<object>(result.Value));
        }
    }
}
