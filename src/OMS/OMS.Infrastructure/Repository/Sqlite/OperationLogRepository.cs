using OMS.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Infrastructure
{
    public class OperationLogRepository : IOperationLogRepository
    {

        private readonly SqliteOperationContext _sqliteContext;

        public OperationLogRepository(SqliteOperationContext sqliteContext)
        {
            _sqliteContext = sqliteContext;
        }

        public async Task AddCallLogAsync(OperationLog entity)
        {
            _sqliteContext.OperationLog.Add(entity);
            await _sqliteContext.SaveChangesAsync();
        }

      
    }
}
