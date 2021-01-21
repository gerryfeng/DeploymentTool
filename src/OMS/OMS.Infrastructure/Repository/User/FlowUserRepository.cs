using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OMS.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OMS.Infrastructure
{
    public class FlowUserRepository : BaseRepository<Flow_Users>, IFlowUserRepository
    {

        private readonly BaseDBContext _dbContext;
        private readonly ILogger<FlowUserRepository> _logger;

        public FlowUserRepository(BaseDBContext dBContext, ILogger<FlowUserRepository> logger) :base(dBContext)
        {
            _dbContext = dBContext;
            _logger = logger;
        }

        public async Task<List<Flow_Users>> GetListAsync(Q_User where)
        {
            return await Query(where).ToListAsync();
        }


        public IQueryable<Flow_Users> Query(Q_User where)
        {
            IQueryable<Flow_Users> query = _dbContext.Users.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(where.LoginName))
                query = query.Where(x => x.工号 == where.LoginName);

            if (!string.IsNullOrWhiteSpace(where.PassWord))
                query = query.Where(x => x.Password == where.PassWord);

            if (where.UserIds?.Count > 0)
                query = query.Where(x => where.UserIds.Contains(x.用户id));

            if (where.IncludeGroup)
                query = query.Include(x => x.UserRoles).ThenInclude(x => x.Group);
            else if (where.IncludeUserRole)
                query = query.Include(x => x.UserRoles);
            
            return query;
        }

       

        public string GetUserImg(string userID)
        {
            Regex regNum = new Regex("^[0-9]*$");
            if (regNum.IsMatch(userID))
            {
                return _dbContext.Users.FirstOrDefault(x => x.用户id == int.Parse(userID))?.Userimge;
            }
            else
            {
                //string sql = "select * from GIS_工程角色管理表 where 工程名 ='" + userID + "'";
                //return _dbContext.Users.FromSql(sql).Select();
                return "";           
            }
        }

        public async Task SetUserRoleAsync(List<Flow_User_Role> delRoles, List<Flow_User_Role> AddRoles)
        {
            try
            {
                foreach (Flow_User_Role r in delRoles)
                {
                    _dbContext.Roles.Remove(r);
                }
                await _dbContext.SaveChangesAsync();

                foreach (Flow_User_Role r in AddRoles)
                {
                    _dbContext.Roles.Add(r);
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }


        public string DeleteUsersAsync(List<Flow_Users> users, string userIds, string connStr)
        {
            //插入恢复用户
            try
            {
                StringBuilder sb = new StringBuilder("insert into recoveryuser(用户ID,工号,名称,机构ID,机构名称,用户信息,隐藏,插入时间,已恢复,恢复时间) values ");
                users.ForEach(x =>
                {
                    Flow_Groups g = x.UserRoles.FirstOrDefault(x => x.Group.类型 == 1)?.Group;
                    Flow_Users u = x; 
                    u.UserRoles = null; 
                    sb.Append($"('{x.用户id}', '{x.工号}', '{x.名称}', {g?.机构ID ?? 0}, '{g?.名称}', '{JsonConvert.SerializeObject(u)}','0',GETDATE(),'0','') ,");
                });
                SqlHelper.ExecuteNonQuery(sb.ToString().TrimEnd(','), connStr);

                //删除用户先关信息
                List<string> sqlList = new List<string>();
                sqlList.Add($"update flow_groups set 主管人 = NULL where 主管人 in ({userIds})");
                sqlList.Add($"delete flow_user_role where 用户ID in ({userIds})");
                sqlList.Add($"delete flow_users where 用户ID in ({userIds})");
                sqlList.Add($"delete LayerRole_User_LayerRole where UserID in ({userIds})");
                SqlHelper.ExecuteNonQuery(sqlList, connStr);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "";
        }


        /// <summary>
        /// 批量更新用户角色关系
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public string ExcuteSql(List<string> sqls, string connStr)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(sqls, connStr);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "";
        }

    }
}
