using System;
using System.Collections.Generic;
using System.Text;

namespace OMS.ApplicationCore
{
    public class GroupUserModel
    {
        /// <summary>
        /// 分组id
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; set; }

        public List<UserItem> Users { get; set; } = new List<UserItem>();
    }
}
