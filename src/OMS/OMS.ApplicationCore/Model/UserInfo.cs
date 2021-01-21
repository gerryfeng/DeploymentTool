using System.Collections.Generic;

namespace OMS.ApplicationCore
{
    public class UserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int OID { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string fullName { get; set; }

        /// <summary>
        /// 登录名称
        /// </summary>
        public string loginName { get; set; }

        /// <summary>
        /// 部门信息
        /// </summary>
        public DepartRole depart { get; set; }

        /// <summary>
        /// 角色信息
        /// </summary>
        public List<DepartRole> roles { get; set; }

        /// <summary>
        /// 导出CAD信息
        /// </summary>
        public ExportCAD exportCAD { get; set; }

        /// <summary>
        /// 企业站点site
        /// </summary>
        public string site { get; set; }

        /// <summary>
        /// Email信息
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 钉钉ID
        /// </summary>
        public string DDid { get; set; }

        /// <summary>
        /// 微信ID
        /// </summary>
        public string WXid { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserImge { get; set; }

        /// <summary>
        /// 用户备注
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 微信名称
        /// </summary>
        public string WxName { get; set; }

        /// <summary>
        /// 微信头像
        /// </summary>
        public string WxImage { get; set; }

        /// <summary>
        /// 是否是企业管理员
        /// </summary>
        public string IsManager { get; set; }

        /// <summary>
        /// 子站IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 子站端口Port
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// GIS接入状态
        /// </summary>
        public string GisState { get; set; }

        /// <summary>
        /// 所在城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 用户令牌
        /// </summary>
        public string token { get; set; }

        /// <summary>
        /// 用户令牌过期时间
        /// </summary>
        public string tokenexp { get; set; }

        /// <summary>
        /// 企业类型
        /// </summary>
        public string EnterprisesType { get; set; }

        /// <summary>
        /// 用户所有子站企业的信息
        /// </summary>
        public List<GroupsInfoModel> Groups { get; set; }

        /// <summary>
        /// 云平台用户ID
        /// </summary>
        public int cloudStationOID { get; set; }

        /// <summary>
        /// 附加信息
        /// </summary>
        public string extraInfo { get; set; }

        /// <summary>
        /// 本地企业站点site
        /// </summary>
        public string LocalSite { get; set; }
    }

    public class DepartRole
    {
        public int OID { get; set; }

        public string name { get; set; }

        public string code { get; set; }
        public string type { get; set; }
    }

    public class ExportCAD
    {
        public bool IPValid { get; set; }

        public double area { get; set; }
    }

    public class GroupsInfoModel
    {
        public GroupsInfoModel()
        {
            city = "";
            groupName = "";
            groupType = "";
            stationIP = "";
            stationPort = "";
            site = "";
            groupID = "";
            isDeployed = false;
            promoteIndex = 0;
            promoteTip = "";
        }
        ///<summary>
        ///所属城市
        ///</summary>
        public string city;
        ///<summary>
        // 企业名称
        /// </summary>
        public string groupName;
        ///<summary>
        // 企业名称
        /// </summary>
        public string groupType;
        ///<summary>
        // 企业所属行业
        /// </summary>
        public string industry;
        ///<summary>
        // 企业ID
        /// </summary>
        public string groupID;
        ///<summary>
        ///站点IP
        ///</summary>
        public string stationIP;
        ///<summary>
        ///站点端口号
        ///</summary>
        public string stationPort;
        ///<summary>
        ///站点site
        ///</summary>
        public string site;
        ///<summary>
        ///企业接入状态
        ///</summary>
        public bool isDeployed;
        ///<summary>
        ///推荐顺寻
        ///</summary>
        public int promoteIndex;
        ///<summary>
        ///推荐标志
        ///</summary>
        public string promoteTip;
    }
}
