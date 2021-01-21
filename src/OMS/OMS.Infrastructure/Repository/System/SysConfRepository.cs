using Microsoft.EntityFrameworkCore;
using OMS.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Infrastructure
{
    public  class SysConfRepository : BaseRepository<Sys_Configuration>, ISysConfRepository
    {

        private readonly BaseDBContext _dbContext;
      
        public SysConfRepository(BaseDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        /// <summary>
        /// 获取机构列表
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public async Task<List<Sys_Configuration>> GetListAsync(Q_SysConf where)
        {
            return await Task.Run(() => Query(where).OrderBy(x => x.ModifyTime).ToList());
        }

        public IQueryable<Sys_Configuration> Query(Q_SysConf where)
        {
            IQueryable<Sys_Configuration> query = _dbContext.Sys_Configurations.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(where.pModuleName))
                query = query.Where(x => x.PModuleName.Contains(where.pModuleName));

            if (!string.IsNullOrWhiteSpace(where.moduleName))
                query = query.Where(x => x.ModuleName.Contains(where.moduleName));


            if (where.isEnable.HasValue)
                query = query.Where(x => x.IsEnable == where.isEnable.Value);

            return query;
        }
    }
   }
