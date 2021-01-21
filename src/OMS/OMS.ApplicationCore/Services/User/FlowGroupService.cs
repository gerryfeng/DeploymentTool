using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace OMS.ApplicationCore
{
   public class FlowGroupService : IFlowGroupService
    {

        private readonly IFlowGroupRepository _repository;
        private readonly IFlowUserRepository _userRepository;
        private readonly ISysMenuRepository _menuRepository;
        private readonly ILogger<FlowGroupService> _logger;
        private readonly IMapper _mapper;

        public FlowGroupService(IFlowGroupRepository repository, ILogger<FlowGroupService> logger, IMapper mapper, IFlowUserRepository userRepository, ISysMenuRepository menuRepository) 
        {
            _repository = repository;
            _userRepository = userRepository;
            _menuRepository = menuRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取机构用户
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public async Task<GroupUser> GetGroupUser(int groupId)
        {
            List<Flow_Groups> groups = await _repository.GetListAsync(new Q_Group() { Include = true });

            Flow_Groups g = groups.FirstOrDefault(x => x.机构ID == groupId);

            if (g == null)
            {
                throw new Exception("未查询到此机构！");
            }

            GroupUser pGroup = new GroupUser()
            {
                GroupId = g.机构ID,
                GroupName = g.名称,
                Level = g.级别,
                Description = g.描述,
                Users = g.UserRoles.Select(y =>
                {
                    UserItem m = _mapper.Map<UserItem>(y.User);
                    m.isManager = g.主管人.HasValue && m.userID == g.主管人.Value.ToString() ? true : false;
                    return m;
                }).ToList(),
            };

            FindChildren(pGroup, groups, g.编码, g.级别 + 1);

            return pGroup;
        }

        private void FindChildren(GroupUser pGroup, List<Flow_Groups> groups, string code, int level)
        {

            List<GroupUser> childList = new List<GroupUser>();
            foreach (Flow_Groups g in groups)
            {
                if (g.编码.StartsWith(code + "-") && g.级别 == level)
                {
                    GroupUser childItem = new GroupUser();
                    childItem.GroupId = g.机构ID;
                    childItem.GroupName = g.名称;
                    childItem.Level = g.级别;
                    childItem.Description = g.描述;
                    childItem.Users = g.UserRoles.Select(y =>
                    {
                        UserItem m = _mapper.Map<UserItem>(y.User);
                        m.isManager = g.主管人.HasValue && m.userID == g.主管人.Value.ToString() ? true : false;
                        return m;
                    }).ToList();

                    FindChildren(childItem, groups, g.编码, level + 1);
                    childList.Add(childItem);
                }
            }
            pGroup.Childs = childList;
        }

        #region 角色产品分组
        /// <summary>
        /// 角色产品分组
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="WebGIS"></param>
        /// <returns></returns>
        public async Task<RoleGroupResult> GetUserRelationAsync(string userID, XmlDocument doc, List<SubSystemModel> subSystems, string rootPath, string connStr, bool WebGIS = false)
       {
            RoleGroupResult result = new RoleGroupResult();

            List<Flow_Groups> groups = await _repository.GetListAsync(new Q_Group() { type = 2, notEqualNames = new List<string>() { "站点_", "地图_" } });
            List<Flow_Groups> roles = await Task.Run(() => _repository.GetGroupIdByUserId(userID, connStr, WebGIS));

            var group1 = groups.Where(x => !x.名称.StartsWith("站点_") && !x.名称.StartsWith("地图_")).OrderBy(x => x.VISIBLE).ToList();
            result.roleList = await Task.Run(() => GetUserRoleListForWeb4( doc, subSystems, group1, roles, WebGIS)) ;

            Regex regNum = new Regex("^[0-9]*$");

            if (regNum.IsMatch(userID.ToString()) && WebGIS == false)
            {
                var group2 = groups.Where(x => x.名称.StartsWith("站点_") ).OrderBy(x =>  x.VISIBLE).ToList();
                result.stationList = await Task.Run(() => GetUserStationList( group2, roles, subSystems));
                result.headList = Web4GetUserHeadList(userID,rootPath);
                result.mobileMapList = await GetUserMobileMapListAsync(roles, connStr);
            }
            return result;
        }


        
        private List<UserRoleListResult> GetUserRoleListForWeb4( XmlDocument doc, List<SubSystemModel> subSystems, List<Flow_Groups> groups, List<Flow_Groups> roles, bool WebGIS = false)
        {
            List<UserRoleListResult> result = new List<UserRoleListResult>();
            
            #region 数据处理
            string preVisibleValue = "-1";

            UserRoleListResult OtherRole = new UserRoleListResult();
            OtherRole.visibleValue = "其它角色";
            OtherRole.visibleTitle = "其它角色";

            #region Web4.0

            Dictionary<string, string> dicTitle = new Dictionary<string, string>();
            XmlNodeList websiteList = doc.SelectNodes(@"/configuration/website");
            foreach (XmlNode xmlNode in websiteList)
            {
                dicTitle.Add(xmlNode.SelectSingleNode("client").InnerText.Trim(), xmlNode.SelectSingleNode("title").InnerText.Trim());
            }
            //dicTitle.Add("miniapp", "小程序");

            XmlNodeList mobileList = doc.SelectNodes(@"/configuration/MiniAPPSite");
            List<string> mobileClients = new List<string>();
            foreach (XmlNode xmlNode in mobileList)
            {
                string clinet = xmlNode.SelectSingleNode("client").InnerText.Trim();
                dicTitle.Add(clinet, xmlNode.SelectSingleNode("title").InnerText.Trim());
                mobileClients.Add(clinet);
            }

            List<UserRoleListResult> web4Role = new List<UserRoleListResult>();
            #endregion

            foreach (Flow_Groups g in groups)
            {
                string strVisibleTitle = "";
                string strVisibleValue = g.VISIBLE;
                string strRoleID = g.机构ID.ToString();
                string strRoleName = g.名称;

                bool valid = false;
                for (int j = 0; j < subSystems.Count; j++)
                {
                    if (strVisibleValue == subSystems[j].value)
                    {
                        strVisibleTitle = subSystems[j].title;
                        valid = true;
                        break;
                    }
                }

                if (valid)
                {
                    if (preVisibleValue != strVisibleValue)
                    {
                        UserRoleListItem item = new UserRoleListItem();
                        item.roleID = strRoleID;
                        item.roleName = strRoleName;
                        item.isChecked = roles.Any(x => x.机构ID == g.机构ID);
                        item.description = g.描述;
                        
                        UserRoleListResult Roleitem = new UserRoleListResult();
                        Roleitem.visibleValue = strVisibleValue;
                        Roleitem.visibleTitle = strVisibleTitle;
                        Roleitem.type = mobileClients.Contains(strVisibleValue) ? "mobile" : "web";

                        if (!string.IsNullOrWhiteSpace(g.备注))
                        {
                            UserRoleListResult child = new UserRoleListResult();
                            child.visibleValue = strVisibleValue;
                            child.visibleTitle = g.备注;
                            child.type = mobileClients.Contains(strVisibleValue) ? "mobile" : "web";
                            child.roleList.Add(item);
                            Roleitem.child.Add(child);
                        }
                        else
                            Roleitem.roleList.Add(item);

                        result.Add(Roleitem);

                        preVisibleValue = strVisibleValue;
                    }
                    else
                    {
                        UserRoleListItem item = new UserRoleListItem();
                        item.roleID = strRoleID;
                        item.roleName = strRoleName;
                        item.isChecked = roles.Any(x => x.机构ID == g.机构ID);
                        item.description = g.描述;

                        if (!string.IsNullOrWhiteSpace(g.备注) && g.备注 != result.Last().visibleTitle)
                        {
                            if(result.Last().child.Any(x => x.visibleTitle == g.备注))
                            {
                                result.Last().child.FirstOrDefault(x => x.visibleTitle == g.备注).roleList.Add(item);
                            }
                            else
                            {
                                UserRoleListResult child = new UserRoleListResult();
                                child.visibleValue = strVisibleValue;
                                child.visibleTitle = g.备注;
                                child.roleList.Add(item);
                                child.type = mobileClients.Contains(strVisibleValue) ? "mobile" : "web";
                                result.Last().child.Add(child);
                            }
                        }
                        else
                            result.Last().roleList.Add(item);


                    }
                }
                else
                {
                    bool isexits = false;
                    foreach (KeyValuePair<string, string> kv in dicTitle)
                    {
                        if (kv.Key == strVisibleValue)
                        {
                            if (preVisibleValue != strVisibleValue)
                            {
                                UserRoleListItem itemWeb4 = new UserRoleListItem();
                                itemWeb4.roleID = strRoleID;
                                itemWeb4.roleName = strRoleName;
                                itemWeb4.isChecked = roles.Any(x => x.机构ID == g.机构ID);
                                itemWeb4.description = g.描述;

                                UserRoleListResult RoleitemWeb4 = new UserRoleListResult();
                                RoleitemWeb4.visibleValue = strVisibleValue;
                                RoleitemWeb4.visibleTitle = kv.Value;
                                RoleitemWeb4.type = mobileClients.Contains(strVisibleValue) ? "mobile" : "web";

                                if (!string.IsNullOrWhiteSpace(g.备注))
                                {
                                    UserRoleListResult child = new UserRoleListResult();
                                    child.visibleValue = strVisibleValue;
                                    child.visibleTitle = g.备注;
                                    child.type = mobileClients.Contains(strVisibleValue) ? "mobile" : "web";
                                    child.roleList.Add(itemWeb4);
                                    RoleitemWeb4.child.Add(child);
                                }
                                else
                                    RoleitemWeb4.roleList.Add(itemWeb4);

                                web4Role.Add(RoleitemWeb4);

                                preVisibleValue = strVisibleValue;
                            }
                            else
                            {
                                UserRoleListItem RoleitemWeb4 = new UserRoleListItem();
                                RoleitemWeb4.roleID = strRoleID;
                                RoleitemWeb4.roleName = strRoleName;
                                RoleitemWeb4.isChecked = roles.Any(x => x.机构ID == g.机构ID);
                                RoleitemWeb4.description = g.描述;

                                if (!string.IsNullOrWhiteSpace(g.备注) && g.备注 != web4Role.Last().visibleTitle)
                                {
                                    if (web4Role.Last().child.Any(x => x.visibleTitle == g.备注))
                                    {
                                        web4Role.Last().child.FirstOrDefault(x => x.visibleTitle == g.备注).roleList.Add(RoleitemWeb4);
                                    }
                                    else
                                    {
                                        UserRoleListResult child = new UserRoleListResult();
                                        child.visibleValue = strVisibleValue;
                                        child.visibleTitle = g.备注;
                                        child.type = mobileClients.Contains(strVisibleValue) ? "mobile" : "web";
                                        child.roleList.Add(RoleitemWeb4);
                                        web4Role.Last().child.Add(child);
                                    }
                                }
                                else

                                    web4Role.Last().roleList.Add(RoleitemWeb4);
                            }
                            isexits = true;
                            break;
                        }
                    }
                    if (!isexits)
                    {
                        UserRoleListItem item = new UserRoleListItem();
                        item.roleID = strRoleID;
                        item.roleName = strRoleName;
                        item.isChecked = roles.Any(x => x.机构ID == g.机构ID);
                        item.description = g.描述;

                        OtherRole.roleList.Add(item);
                    }
                }
            }
            if (web4Role.Count > 0)
                result.AddRange(web4Role);

            if (OtherRole.roleList.Count > 0)
            {
                result.Add(OtherRole);
            }
            #endregion

            List<string> visibles = result.Select(x => x.visibleValue).Distinct().ToList();
            foreach(var dic in dicTitle)
            {
                if (!visibles.Contains(dic.Key))
                {
                    result.Add(new UserRoleListResult() { 
                        visibleTitle = dic.Value,
                        visibleValue = dic.Key,
                        type = mobileClients.Contains(dic.Key) ? "mobile" : "web"
                    });
                }
            }

            result = result.OrderByDescending(x => x.type).ToList();

            return result;
        }

        

        private List<UserHeadListResult> Web4GetUserHeadList(string userID,string rootPath)
        {

            List<UserHeadListResult> result = new List<UserHeadListResult>();

            UserHeadListResult resultItem = new UserHeadListResult();
            resultItem.visibleTitle = "巡检人员图标";
            resultItem.visibleValue = "巡检人员图标";
            result.Add(resultItem);

            string path = rootPath + @"\Web4\assets\images\patroler\";
            if (!Directory.Exists(path))
                path = rootPath + @"CityWebFW\Product\Patrol\BufFile\OutFiles\UpLoadFiles\UserImage\";

            if (!Directory.Exists(path))
                return result;


            foreach (string file in Directory.GetFiles(path))
            {
                FileInfo fi = new FileInfo(file);

                string newName = fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length) + "_offline" + fi.Extension;

                if (File.Exists(path + newName))
                {
                    UserHeadListItem item = new UserHeadListItem();

                    item.headID = fi.Name;
                    item.headName = fi.Name;

                    item.headUrl = "../Web4/assets/images/patroler/" + fi.Name;
                    if (!Directory.Exists(rootPath + @"\Web4\assets\images\patroler\"))
                    {
                        item.headUrl = "../CityWebFW/Product/Patrol/BufFile/OutFiles/UpLoadFiles/UserImage/" + fi.Name;
                    }

                    item.headType = fi.Extension.ToLower() == ".swf" ? "swf" : "image";
                    item.isChecked = false;

                    if (fi.Name == _userRepository.GetUserImg(userID))
                    {
                        item.isChecked = true;
                    }

                    result[0].headList.Add(item);
                }
            }

            return result;
        }


        private List<UserStationListResult> GetUserStationList( List<Flow_Groups> groups, List<Flow_Groups> roles, List<SubSystemModel> subSystems)
        {

            List<UserStationListResult> result = new List<UserStationListResult>();

            string preVisibleValue = "-1";
            
            UserStationListResult OtherStation = new UserStationListResult();
            OtherStation.visibleValue = "其它站点";
            OtherStation.visibleTitle = "其它站点";

            foreach (Flow_Groups g in groups)
            {
                string strVisibleTitle = "";
                string strVisibleValue = g.VISIBLE;
                string strStationID = g.机构ID.ToString();
                string strStationName = g.名称.Substring("站点_".Length);

                bool valid = false;
                for (int j = 0; j < subSystems.Count; j++)
                {
                    if (strVisibleValue == subSystems[j].value)
                    {
                        strVisibleTitle = subSystems[j].title;
                        valid = true;
                        break;
                    }
                }

                if (valid)
                {
                    if (preVisibleValue != strVisibleValue)
                    {
                        UserStationListItem item = new UserStationListItem();
                        item.stationID = strStationID;
                        item.stationName = strStationName;
                        item.isChecked = roles.Any(x => x.机构ID == g.机构ID);

                        UserStationListResult Roleitem = new UserStationListResult();
                        Roleitem.visibleValue = strVisibleValue;
                        Roleitem.visibleTitle = strVisibleTitle;
                        Roleitem.stationList.Add(item);

                        result.Add(Roleitem);

                        preVisibleValue = strVisibleValue;
                    }
                    else
                    {
                        UserStationListItem item = new UserStationListItem();
                        item.stationID = strStationID;
                        item.stationName = strStationName;
                        item.isChecked = roles.Any(x => x.机构ID == g.机构ID);

                        result.Last().stationList.Add(item);
                    }
                }
                else
                {
                    UserStationListItem item = new UserStationListItem();
                    item.stationID = strStationID;
                    item.stationName = strStationName;
                    item.isChecked = roles.Any(x => x.机构ID == g.机构ID);

                    OtherStation.stationList.Add(item);
                }
            }

            if (OtherStation.stationList.Count > 0)
            {
                result.Add(OtherStation);
            }

            return result;
        }


        private async Task<List<UserMobileMapListResult>> GetUserMobileMapListAsync( List<Flow_Groups> roles,  string connStr)
        {
            List<UserMobileMapListResult> result = new List<UserMobileMapListResult>();

            int k = 0;
            List<string> client = new List<string>();

            //if (!DbOper.MobileCheckTable())
            //{
            //    DbOper.MobileCreateTable();
            //}

            DataTable dt = await _menuRepository.GetMobileMapConfigs("", connStr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Name"].ToString();

                if (dt.Rows[i]["ClientType"].ToString() == "all")
                {
                    if (!client.Contains(dt.Rows[i]["ClientType"].ToString()))
                    {
                        UserMobileMapListResult resultItem = new UserMobileMapListResult();
                        resultItem.visibleTitle = "通用";
                        resultItem.visibleValue = "通用";
                        result.Insert(0, resultItem);

                        client.Add(dt.Rows[i]["ClientType"].ToString());
                    }

                    if (dt.Rows[i]["Name"].ToString() == "默认配置")
                        continue;
                    else
                    {
                        UserMobileMapListItem item = new UserMobileMapListItem();

                        item.solutionID = name;
                        item.solutionName = name;
                        item.chkName = dt.Rows[i]["ClientType"].ToString();

                        item.isChecked = false;
                        foreach (Flow_Groups g in roles)
                        {
                            if (g.名称.StartsWith("地图_")
                                && g.名称.Substring("地图_".Length) == name
                                && g.VISIBLE == "手持系统")
                            {
                                item.isChecked = true;
                            }
                        }
                        result[0].mobileMapList.Add(item);
                    }

                    k++;
                }
                else
                {
                    if (!client.Contains(dt.Rows[i]["ClientType"].ToString()))
                    {
                        UserMobileMapListResult resultItem = new UserMobileMapListResult();
                        resultItem.visibleTitle = dt.Rows[i]["ClientType"].ToString(); ;
                        resultItem.visibleValue = dt.Rows[i]["ClientType"].ToString(); ;
                        result.Add(resultItem);

                        client.Add(dt.Rows[i]["ClientType"].ToString());
                    }

                    UserMobileMapListItem item = new UserMobileMapListItem();
                    item.solutionID = name;
                    item.solutionName = name;
                    item.chkName = dt.Rows[i]["ClientType"].ToString();

                    item.isChecked = false;
                    foreach (Flow_Groups g in roles)
                    {
                        if (g.名称.StartsWith("地图_")
                            && g.名称.Substring("地图_".Length) == name
                            && g.VISIBLE == "手持系统")
                        {
                            item.isChecked = true;
                        }
                    }

                    for (int j = 0; j < result.Count; j++)
                    {
                        if (result[j].visibleTitle == dt.Rows[i]["ClientType"].ToString())
                        {
                            result[j].mobileMapList.Add(item);
                            break;
                        }
                    }
                }
            }

            return result;
        }



        #endregion


        #region 站点角色管理
        public async Task<List<UserItem>> GetStationUserList(int groupId, int stationId)
        {
            List<Flow_Groups> groups = await _repository.GetListAsync(new Q_Group() { Include = true, ouids = new List<int>() { groupId, stationId } });
            List<int> stationUsers = groups.FirstOrDefault(x => x.机构ID == stationId)?.UserRoles?.Select(x => x.User.用户id)?.ToList() ?? new List<int>();
            return groups.FirstOrDefault(x => x.机构ID == groupId)?.UserRoles?.Select(x => {
                                UserItem m = _mapper.Map<UserItem>(x.User);
                                m.isChecked = stationUsers.Contains(x.用户ID);
                                 return m;
                            }).ToList();
        }



        /// <summary>
        /// 获取机构用户分页列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public PagedList<GroupUserModel> GroupUserPagingList(Q_Group where)
        {
            PagedList<GroupUserModel> pagedList = null;
            where.Include = true;
            where.IsUserCanNull = true;
            where.type = 1;
            PagedList<Flow_Groups> groups =  _repository.GetPagingList(where);

            List<int> stationUsers = _repository.GetById(where.stationId,true)?.UserRoles?.Select(x => x.用户ID)?.ToList() ?? new List<int>();

            if (groups.TotalCount > 0)
            {
                List<GroupUserModel> GroupList = groups.list.Select(x => {
                    GroupUserModel k = new GroupUserModel()
                    {
                        GroupId = x.机构ID,
                        GroupName = x.名称,
                        Users = x.UserRoles?.Select(y =>
                        {
                            UserItem m = _mapper.Map<UserItem>(y.User);
                            m.isChecked = stationUsers.Contains(y.用户ID);
                            return m;
                        }).ToList()
                    };
                    return k;
                }).ToList();
                pagedList= new PagedList<GroupUserModel>(GroupList, groups.PageIndex, groups.PageSize, groups.TotalCount, groups.TotalPages);
            }
            return pagedList;
        }

        #endregion
    }
}
