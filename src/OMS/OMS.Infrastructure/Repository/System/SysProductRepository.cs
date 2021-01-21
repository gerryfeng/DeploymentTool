using Microsoft.EntityFrameworkCore;
using OMS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public class SysProductRepository: BaseRepository<Sys_Product>, ISysProductRepository
    {
        private readonly BaseDBContext _dbContext;

        public SysProductRepository(BaseDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        /// <summary>
        /// 获取机构列表
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public async Task<List<Sys_Product>> GetListAsync(Q_SysProduct where)
        {
            return await Task.Run(() => Query(where).OrderBy(x => x.Id).ToList());
        }

        public IQueryable<Sys_Product> Query(Q_SysProduct where)
        {
            IQueryable<Sys_Product> query = where.IsAsTrack ? _dbContext.Sys_Products.AsQueryable(): _dbContext.Sys_Products.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(where.productName))
                query = query.Where(x => x.ProductName.Contains(where.productName));

            if (!string.IsNullOrWhiteSpace(where.environment))
                query = query.Where(x => x.Environment.Contains(where.environment));

            if (!string.IsNullOrWhiteSpace(where.ids))
                query = query.Where(x => where.ids.Contains(x.Id.ToString()));

            return query;
        }

        public bool ExistName(string ProductName)
        {
            return _dbContext.Sys_Products.Count(x => x.ProductName == ProductName) > 0;
        }
    }
}
