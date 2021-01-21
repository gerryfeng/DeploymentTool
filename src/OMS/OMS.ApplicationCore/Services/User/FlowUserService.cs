using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public class FlowUserService :  IFlowUserService
    {

        private readonly IFlowUserRepository _userRepository;
        private readonly IFlowGroupRepository _groupRepository;
        private readonly ILogger<FlowUserService> _logger;

        public FlowUserService(IFlowUserRepository userRepository, ILogger<FlowUserService> logger, IFlowGroupRepository groupRepository) 
        {
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _logger = logger;
        }

        /// <summary>
        /// oms登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="superPassword"></param>
        /// <param name="configName"></param>
        /// <param name="configPwd"></param>
        /// <param name="oMSRole">运维管理登录权限</param>
        /// <returns></returns>
        public async Task<CheckUserResult> OMSLoginAsync(string userName, string password, string superPassword, string configName, string configPwd,string oMSRole)
        {
            CheckUserResult data = new CheckUserResult();

            bool isSuper = !string.IsNullOrEmpty(superPassword), superPass = false;

            if (isSuper && password == superPassword)
            {
                superPass = true;
            }
            else if (!isSuper && password == "pandaomsa")
            {
                superPass = true;
            }
            // oms权限管理升级 omsa/pandaomsa 只作为研发内部的使用 - by Edward
            if (userName == "omsa" && superPass)
            {
                data.pass = true;
                data.userMode = "super";
            }
            else if (userName == configName && password == configPwd)
            {
                data.pass = true;
                data.userMode = "admin";
            }
            else
            {
                List<Flow_Users> ulist = await  _userRepository.GetListAsync(new Q_User() { LoginName = userName, PassWord = EncryptHelper.SHA1_Encrypt(password),IncludeGroup=true });

                if (ulist?.Count == 0)
                    data.pass = false;
                else
                {
                    data.pass = true;
                    data.userMode = "common";
                }
                if(ulist.Any(x => x.UserRoles.Any(y => y.Group.类型 == 2 && y.Group.名称 == oMSRole)))
                {
                    data.userMode = "admin";
                }
            }            
            return data;
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <returns></returns>
        public void UpdateUserPassword(ModifyPwdModel model)
        {
            Flow_Users user = _userRepository.GetModelById(model.UserId);

            if(model.OldPassWord.Trim() != user.Password)
            {
                throw new Exception ("原密码错误！");
            }

            user.Password = EncryptHelper.SHA1_Encrypt(model.NewPassWord);
            _userRepository.Update(user);
        }


        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="userIds">用户ids</param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<string> DeleteUsersAsync(string userIds, string connStr)
        {
            List<int> uids = userIds.Split(',').Select(x => Convert.ToInt32(x)).ToList();

            List<Flow_Users> users = await  _userRepository.GetListAsync(new Q_User() { UserIds = uids, IncludeUserRole = true, IncludeGroup = true }) ;
            if(users?.Count <= 0)
            {
                throw new Exception("未查询到用户信息!");
            }

            return _userRepository.DeleteUsersAsync(users, userIds, connStr);
           
        }


        /// <summary>
        /// 批量更新用户角色关系
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public async Task<string> SetUserRoleMapAsync(string userIds, string roleIds, string stationList, string connStr)
        {
            List<int> uids = userIds.Split(',').Select(x => Convert.ToInt32(x)).ToList();

            List<Flow_Users> users = await _userRepository.GetListAsync(new Q_User() { UserIds = uids, IncludeUserRole = true }) ;
            if (users?.Count <= 0)
            {
                throw new Exception ("未查询到用户信息!");
            }

            List<Flow_User_Role> addRols = new List<Flow_User_Role>();
            foreach (int userid in uids)
            {
                addRols.AddRange(roleIds.Split(',').Select(x =>
                {
                    return new Flow_User_Role()
                    {
                        用户ID = userid,
                        机构ID = Convert.ToInt32(x)
                    };
                }).ToList());

                if (!string.IsNullOrEmpty(stationList))
                {
                    addRols.AddRange(stationList.Split(',').Select(x => {
                        return new Flow_User_Role()
                        {
                            用户ID = userid,
                            机构ID = Convert.ToInt32(x)
                        };
                    }).ToList());
                }
            }

            List<string> sqlList = new List<string>();
            if(!string.IsNullOrEmpty(stationList))
                 sqlList.Add($"delete flow_user_role where 用户id in ({userIds}) and 机构ID in (select 机构ID from flow_groups where 类型 =2 and 名称 not like '地图_%')");
            else
                sqlList.Add($"delete flow_user_role where 用户id in ({userIds}) and 机构ID in (select 机构ID from flow_groups where 类型 =2 and 名称 not like '地图_%' and 名称 not like '站点_%')");

            StringBuilder sb = new StringBuilder("insert into flow_user_role (机构id, 用户id) values ");
            foreach(Flow_User_Role r in addRols)
            {
                sb.Append($"({r.机构ID},{r.用户ID}),");
            }
            sqlList.Add(sb.ToString().TrimEnd(','));

            return _userRepository.ExcuteSql(sqlList, connStr);

            //List<Flow_User_Role> delRols = new List<Flow_User_Role>();
            //users.ForEach(x =>
            //    delRols.AddRange(x.UserRoles.Select(y =>
            //    {
            //        return new Flow_User_Role() { 机构ID = y.机构ID, 用户ID = y.用户ID };
            //    }).ToList()));

           // _userRepository.SetUserRole(delRols, addRols);

        }



        /// <summary>
        /// 用户批量更改机构
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="oldGroupIds"></param>
        /// <param name="newGroupId"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<string> ModifyUserRoleAsync(string userIds, string oldGroupIds, int newGroupId, string connStr)
        {
            if (userIds.Split(',').Count() != oldGroupIds.Split(',').Count())
            {
                throw new Exception ("参数不正确！");
            }
            List<string> sqlList = new List<string>();
            sqlList.Add($"update flow_groups set 主管人 = NULL where 主管人 in ({userIds})");

            string[] users = userIds.Split(',');
            string[] groups = oldGroupIds.Split(',');
            for(int i=0; i< users.Count(); i++)
            {
                sqlList.Add($"update flow_user_role set 机构ID = { newGroupId} where 用户ID = {users[i]} and 机构ID = {groups[i]}");
            }
            return await Task.Run(() => _userRepository.ExcuteSql(sqlList, connStr)) ;         
        }
    }
}
