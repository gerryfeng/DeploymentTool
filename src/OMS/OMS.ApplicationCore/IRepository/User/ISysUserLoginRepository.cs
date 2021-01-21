using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public interface ISysUserLoginRepository : IBaseRepository<SysUserLogin>
    {
        Task<List<SysUserLogin>> GetListAsync(Q_Log where);

        PagedList<SysUserLogin> GetPagedList(Q_Log where);
    }
}
