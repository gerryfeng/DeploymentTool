using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public interface IFlowUserService 
    {
        /// <summary>
        /// OMS登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="superPassword">超级管理员密码</param>
        /// <param name="configName">配置文件用户名</param>
        /// <param name="configPwd">配置文件密码</param>
        /// <param name="oMSRole">运维角色</param>
        /// <returns></returns>
        Task<CheckUserResult> OMSLoginAsync(string userName, string password, string superPassword, string configName, string configPwd,string oMSRole);

        /// <summary>
        /// 批量删除用户信息
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="groupId"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        Task<string> DeleteUsersAsync(string userIds,  string connStr);

        /// <summary>
        /// 批量更新用户角色关系
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        Task<string> SetUserRoleMapAsync(string userIds, string roleIds, string stationList, string connStr);

        /// <summary>
        /// 用户批量更改机构
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="oldGroupIds"></param>
        /// <param name="newGroupId"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        Task<string> ModifyUserRoleAsync(string userIds, string oldGroupIds, int newGroupId, string connStr);


        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void UpdateUserPassword(ModifyPwdModel model);
    }
}
