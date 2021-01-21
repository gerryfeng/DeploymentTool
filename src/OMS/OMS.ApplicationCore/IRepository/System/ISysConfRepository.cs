using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public interface ISysConfRepository: IBaseRepository<Sys_Configuration>
    {
        Task<List<Sys_Configuration>> GetListAsync(Q_SysConf where);
    }
}
