using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OMS.ApplicationCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Infrastructure
{
   public class SysMenuRepository : BaseRepository<SysMenu>, ISysMenuRepository
    {
        private readonly BaseDBContext _dbContext;
        private readonly ILogger<SysMenuRepository> _logger;

        public SysMenuRepository(BaseDBContext dBContext, ILogger<SysMenuRepository> logger):base(dBContext)
        {
            _dbContext = dBContext;
            _logger = logger;
        }

        public List<SysMenu> GetList(Q_Menu where)
        {
            return Query(where).OrderBy(x => x.Nodeid).ToList();
        }

        public IQueryable<SysMenu> Query(Q_Menu where)
        {
            IQueryable<SysMenu> query = null;
            if (where.isTrack)
                query = _dbContext.Menus.AsQueryable();
            else
                query = _dbContext.Menus.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(where.visible))
                query = query.Where(x => x.Visible == where.visible);

            if (where.parentIdNotEquals.HasValue)
                query = query.Where(x => x.Parentid != where.parentIdNotEquals.Value);

            if (where.parentIdEquals.HasValue)
                query = query.Where(x => x.Parentid == where.parentIdEquals.Value);

            if (where.isInclude)
                query = query.Include(x => x.Syspurviews);

            return query;
        }

        /// <summary>
        /// 同组下名称唯一，将以前的名称、类型唯一性约束删除
        /// </summary>
        public void DeleteUnique()
        {
            string sql = "select count(*) from sysobjects where xtype = 'UQ' and name = 'UNIQUE_FLOW_GROUPS_NAME_TYPE'";
            _dbContext.Users.FromSqlRaw(sql);
            //if (Int32.Parse(ExecuteScalar(sql)) > 0)
            //{
            //    ExecuteNonQuery("ALTER TABLE [dbo].[FLOW_GROUPS] drop constraint [UNIQUE_FLOW_GROUPS_NAME_TYPE]");
            //}
        }

        public async Task<DataTable> GetMobileMapConfigs(string clientType,string connStr)
        {
           string sql = "select COUNT(*) from sys.all_objects where object_id = OBJECT_ID(N'CIV_MAP_MOBILE')";
            string exist = await Task.Run(() => SqlHelper.ExecuteScalar(sql, connStr)) ;
            if (int.Parse(exist) > 0)
            {
                sql = "select ID,Name,MapConfig,ClientType from CIV_MAP_MOBILE where 1=1 ";
                if (!string.IsNullOrEmpty(clientType))
                    sql += string.Format(" and ClientType = '{0}'", clientType);

                sql += "order by ID,ClientType";

                return SqlHelper.ExecuteDataTable(sql, connStr);
            }
            else
                return new DataTable();
        }
    }
}
