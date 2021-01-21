using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OMS.ApplicationCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Infrastructure
{
    public class FlowGroupRepository : BaseRepository<Flow_Groups>, IFlowGroupRepository
    {

        private readonly BaseDBContext _dbContext;
        private readonly ILogger<FlowGroupRepository> _logger;

        public FlowGroupRepository(BaseDBContext dBContext, ILogger<FlowGroupRepository> logger) :base(dBContext)
        {
            _dbContext = dBContext;
            _logger = logger;
        }

        /// <summary>
        /// 获取机构列表
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public async Task<List<Flow_Groups>> GetListAsync(Q_Group where)
        {
            return await Task.Run(() => Query(where).OrderBy(x => x.机构ID).ToList());
        }

        /// <summary>
        /// 获取机构列表分页
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public PagedList<Flow_Groups> GetPagingList(Q_Group where)
        {
            return new PagedList<Flow_Groups>(Query(where).OrderByDescending(x => x.机构ID), where.PageIndex, where.PageSize);
        }

        public IQueryable<Flow_Groups> Query(Q_Group where)
        {
            IQueryable<Flow_Groups> query = _dbContext.Groups.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(where.visible))
                query = query.Where(x => x.VISIBLE == where.visible);

            if (where.type > 0)
                query = query.Where(x => x.类型 == where.type);

            if (where.ouids != null && where.ouids.Count > 0)
                query = query.Where(x => where.ouids.Contains(x.机构ID));

            if (!string.IsNullOrWhiteSpace(where.name))
                query = query.Where(x => x.名称.Contains(where.name));

            if (where.notEqualNames != null && where.notEqualNames.Count > 0)
            {
                where.notEqualNames.ForEach(w => {
                    query = query.Where(x => !x.名称.StartsWith("w"));               
                });
            }

            if (where.Include)
                query = query.Include(x => x.UserRoles).ThenInclude(x => x.User);

            if (!string.IsNullOrWhiteSpace(where.token))
                query = query.Where(x => x.UserRoles.Any(y => y.User.Token == where.token));

            //查询机构下存在用户的数据
            if(where.IsUserCanNull)
                query = query.Where(x => x.UserRoles != null && x.UserRoles.Count > 0);

            return query;
        }

        public List<Flow_Groups> GetGroupIdByUserId(string userID, string connStr, bool WebGIS = false)
        {
            int uid;

            if(int.TryParse(userID, out uid) && WebGIS == false)
            {
                var query = from t1 in _dbContext.Groups
                            join t2 in _dbContext.Roles on t1.机构ID equals t2.机构ID
                            join t3 in _dbContext.Users on t2.用户ID equals t3.用户id
                            where t1.类型 == 2 && t3.用户id == uid
                            select t1;
                return query.ToList();
            }
            else
            {
               string sql = string.Format(@"select * from GIS_工程角色管理表 where 工程名 = '{0}'", userID);
                var prodata = SqlHelper.ExecuteDataTable(sql, connStr);
                if (prodata.Rows.Count == 0)
                {
                    sql = string.Format(@"insert into  GIS_工程角色管理表 (工程名) values('{0}')", userID);
                    SqlHelper.ExecuteNonQuery(sql, connStr);
                    sql = string.Format(@"  select * from FLOW_USER_ROLE t1,FLOW_GROUPS t2
                                        where t1.机构ID = t2.机构ID
                                        and t2.类型 = 2
                                        and t1.机构ID in ({0});", 0);
                }
                else
                {
                    var roleList = prodata.Rows[0]["关联角色"].ToString();
                    if (roleList == "")
                    {
                        roleList = "0";
                    }

                    sql = string.Format(@"  select * from FLOW_USER_ROLE t1,FLOW_GROUPS t2
                                        where t1.机构ID = t2.机构ID
                                        and t2.类型 = 2
                                        and t1.机构ID in ({0});", roleList);
                }
               return  SqlHelper.DataTableToIList<Flow_Groups>( SqlHelper.ExecuteDataTable(sql, connStr));
            }
        }

        public Flow_Groups GetById(int groupId,bool isInclue = false)
        {
            if (isInclue)
                return _dbContext.Groups.Include(x => x.UserRoles).ThenInclude(x => x.User).FirstOrDefault(x => x.机构ID == groupId);
            else
                return _dbContext.Groups.FirstOrDefault(x => x.机构ID == groupId);
        }
    }
}
