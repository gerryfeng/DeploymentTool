using Microsoft.EntityFrameworkCore;
using OMS.ApplicationCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Infrastructure
{
    public class SysMapSetRepository : BaseRepository<Sys_Map_ResetRangeConfig>, ISysMapSetRepository
    {
        private readonly BaseDBContext _dbContext;

        public SysMapSetRepository(BaseDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        /// <summary>
        /// 获取机构列表
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public async Task<List<Sys_Map_ResetRangeConfig>> GetListAsync(Q_SysMapSet where)
        {
            return await Task.Run(() => Query(where).OrderBy(x => x.GroupID).ToList());
        }

        public IQueryable<Sys_Map_ResetRangeConfig> Query(Q_SysMapSet where)
        {
            IQueryable<Sys_Map_ResetRangeConfig> query = _dbContext.Sys_Map_ResetRangeConfigs.AsNoTracking();

            if (where.groupID > 0)
                query = query.Where(x => x.GroupID == where.groupID);

            return query;
        }
    }
}
