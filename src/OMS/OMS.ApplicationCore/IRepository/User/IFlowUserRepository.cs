using System.Collections.Generic;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public interface IFlowUserRepository : IBaseRepository<Flow_Users>
    {
        Task<List<Flow_Users>> GetListAsync(Q_User where);

        string GetUserImg(string userID);

        /// <summary>
        /// 添加新的用户关联关系
        /// </summary>
        /// <param name="AddRoles">新的角色</param>
        Task SetUserRoleAsync(List<Flow_User_Role> delRoles, List<Flow_User_Role> AddRoles);


        string DeleteUsersAsync(List<Flow_Users> users, string userIds, string connStr);


        string ExcuteSql(List<string> sqls, string connStr);

    }
}
