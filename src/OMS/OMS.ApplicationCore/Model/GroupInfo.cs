using System.Collections.Generic;

namespace OMS.ApplicationCore
{
    /// <summary>
    /// 机构用户实体
    /// </summary>
    public class GroupUser
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public int Level { get; set; }

        public string Description { get; set; }

        public List<UserItem> Users { get; set; } = new List<UserItem>();

        public List<GroupUser> Childs { get; set; } = new List<GroupUser>();
    }

    public class SimpleGroup
    {
        /// <summary>
        /// 分组id
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; set; }
    }

    public class CheckUserResult 
    {
        /// <summary>
        /// 是否通过验证
        /// </summary>
        public bool pass { get; set; }

        /// <summary>
        /// 用户模式
        /// </summary>
        public string userMode { get; set; }

        public TokenModel token { get; set; }
    }

    public class TokenModel
    {
        public string access_token { get; set; }
  
        public string token_type { get; set; }
       
        public string refresh_token { get; set; }
       
        public string scope { get; set; }
        
        public int expires_in { get; set; }
    }

    /// <summary>
    /// 用户详情
    /// </summary>
    public class UserItem
    {
        public string userID { get; set; }
        public string userName { get; set; }
        public string loginName { get; set; }
        public string mobileVersion { get; set; }
        public string coordinate { get; set; }
        public string userImage { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public bool isManager { get; set; }
        public string OUID { get; set; }//所属机构ID
        public string OUName { get; set; }//所属机构名称
        public string password { get; set; }
        public string roles { get; set; }
        public bool isChecked { get; set; }
        public string ddid { get; set; }
        public string wxid { get; set; }
        public string mark { get; set; }
        public string index { get; set; }
        public string state { get; set; }//新增，用户状态

        public List<DepartRole> menuRoles { get; set; } = new List<DepartRole>();
        public List<DepartRole> devieRoles { get; set; } = new List<DepartRole>();
    }

    #region 角色产品分组  model

    /// <summary>
    /// 角色产品分组
    /// </summary>
    public class RoleGroupResult
    {
        public RoleGroupResult()
        {
            roleList = new List<UserRoleListResult>();
            stationList = new List<UserStationListResult>();
            headList = new List<UserHeadListResult>();
            mobileMapList = new List<UserMobileMapListResult>();
        }

        public List<UserRoleListResult> roleList { get; set; }
        public List<UserStationListResult> stationList { get; set; }
        public List<UserHeadListResult> headList { get; set; }
        public List<UserMobileMapListResult> mobileMapList { get; set; }
    }

    public class UserRoleListResult
    {
        public UserRoleListResult()
        {
            roleList = new List<UserRoleListItem>();
            child = new List<UserRoleListResult>();
        }

        public string visibleTitle { get; set; }
        public string visibleValue { get; set; }
        /// <summary>
        /// 区分web和移动应用
        /// </summary>
        public string type { get; set; }
       
        public List<UserRoleListItem> roleList { get; set; }

        public List<UserRoleListResult> child { get; set; }
    }

    public class UserRoleListItem
    {
        public string roleID { get; set; }
        public bool isChecked { get; set; }
        public string roleName { get; set; }
        public string description { get; set; }
       
    }

    public class UserStationListResult
    {
        public UserStationListResult()
        {
            stationList = new List<UserStationListItem>();
            child = new List<UserStationListResult>();
        }

        public string visibleTitle { get; set; }
        public string visibleValue { get; set; }
        public List<UserStationListItem> stationList;
        public List<UserStationListResult> child;
    }

    public class UserStationListItem
    {
        public string stationID { get; set; }
        public bool isChecked { get; set; }
        public string stationName { get; set; }
    }

    public class UserHeadListResult
    {
        public UserHeadListResult()
        {
            headList = new List<UserHeadListItem>();
        }

        public string visibleTitle { get; set; }
        public string visibleValue { get; set; }
        public List<UserHeadListItem> headList { get; set; }
    }

    public class UserHeadListItem
    {
        public string headID { get; set; }
        public bool isChecked { get; set; }
        public string headName { get; set; }
        public string headUrl { get; set; }
        public string headType { get; set; }
    }

    public class UserMobileMapListResult
    {
        public UserMobileMapListResult()
        {
            mobileMapList = new List<UserMobileMapListItem>();
        }

        public string visibleTitle { get; set; }
        public string visibleValue { get; set; }
        public List<UserMobileMapListItem> mobileMapList { get; set; }
    }

    public class UserMobileMapListItem
    {
        public string solutionID { get; set; }
        public bool isChecked { get; set; }
        public string solutionName { get; set; }
        public string chkName { get; set; }
    } 
    #endregion
}
