using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public interface IOperationLogRepository
    {
        Task AddCallLogAsync(OperationLog entity);
    }
}
