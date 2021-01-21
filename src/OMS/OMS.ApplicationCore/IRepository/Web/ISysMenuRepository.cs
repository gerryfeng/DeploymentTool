using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public interface ISysMenuRepository : IBaseRepository<SysMenu>
    {
        List<SysMenu> GetList(Q_Menu where);

        Task<DataTable> GetMobileMapConfigs(string clientType, string connStr);
    }
}
