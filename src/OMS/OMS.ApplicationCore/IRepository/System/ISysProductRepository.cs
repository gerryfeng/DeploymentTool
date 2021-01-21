using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public interface ISysProductRepository : IBaseRepository<Sys_Product>
    {
        Task<List<Sys_Product>> GetListAsync(Q_SysProduct where);

        bool ExistName(string ProductName);
    }
}
