using System.Collections.Generic;

namespace OMS.ApplicationCore
{
    public class Q_User
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        public string PassWord { get; set; }

        public List<int> UserIds { get; set; }

        /// <summary>
        /// 是否包含 Flow_User_Role 表信息
        /// </summary>
        public bool IncludeUserRole { get; set; }

        public bool IncludeGroup { get; set; }

    }
}
