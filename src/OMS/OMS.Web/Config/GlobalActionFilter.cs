using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OMS.ApplicationCore;
using System.Text;

namespace OMS.Web
{
    public class GlobalActionFilter:ActionFilterAttribute
    {
       
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (false && !context.ModelState.IsValid)
            {
                ResponseBase<string> response = new ResponseBase<string>();

                StringBuilder errMsg = new StringBuilder();

                //获取具体的错误消息
                foreach(var item in context.ModelState.Values)
                {
                    foreach(var err in item.Errors)
                    {
                        errMsg.Append(err.ErrorMessage + " | ");
                    }
                }

                response.SetError(errMsg.ToString().TrimEnd(new char[] { '|', ' ' }));
                context.Result = new JsonResult(response);
            }
            else
                base.OnActionExecuting(context);
        }
    }
}
