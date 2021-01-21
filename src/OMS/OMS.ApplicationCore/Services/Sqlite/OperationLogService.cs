using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMS.ApplicationCore
{
    public class OperationLogService: IOperationLogService
    {
        private readonly IOperationLogRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private System.Diagnostics.StackTrace st;
        public OperationLogService(IOperationLogRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            st = new System.Diagnostics.StackTrace();
        }
        public void AddOperationLog(string method,string Lable, int Level, string queryInfo, string result, string Info = "")
        {
            try
            {
                if (Info == "") Info = _httpContextAccessor.HttpContext.Request.Host+ _httpContextAccessor.HttpContext.Request.Path;

                _repository.AddCallLogAsync(new OperationLog()
                {
                    Function = method,
                    IP = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Label = Lable,
                    Info = Info,
                    ShortInfo = queryInfo,
                    Stack = result,
                    LogTime = DateTime.Now.ToString("s"),
                    Level = Level,

                });
            }
            catch (Exception ex)
            {

            }
        }
    }
}
