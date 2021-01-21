
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public interface ISysMapSetRepository : IBaseRepository<Sys_Map_ResetRangeConfig>
    {
        Task<List<Sys_Map_ResetRangeConfig>> GetListAsync(Q_SysMapSet where);
    }
}
