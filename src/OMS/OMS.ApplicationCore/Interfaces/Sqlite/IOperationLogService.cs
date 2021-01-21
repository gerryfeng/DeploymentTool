using System;
using System.Collections.Generic;
using System.Text;

namespace OMS.ApplicationCore
{
    public interface IOperationLogService
    {
       void AddOperationLog(string method,string Lable, int Level, string queryInfo, string result, string Info = "");
    }
}
