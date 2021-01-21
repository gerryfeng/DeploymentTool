using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OMS.ApplicationCore
{
    public class Q_Group:Q_Base
    {
        /// <summary>
        /// 
        /// </summary>
        public string visible { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int type { get; set; }

        public int? ouid { get; set; }

        public List<int> ouids { get; set; }

        public string name { get; set; }

        /// <summary>
        /// web4中不包含   "站点_", "地图_"
        /// </summary>
        public List<string> notEqualNames { get; set; }

        /// <summary>
        /// 是否关联查询出用户
        /// </summary>
        public bool Include { get; set; }
        /// <summary>
        /// 是否查询出用户未空的机构
        /// </summary>
        public bool IsUserCanNull { get; set; }

        public int stationId { get; set; }

        /// <summary>
        /// 用户token
        /// </summary>
        public string token { get; set; }
    }


    public class Q_GropUser : Q_Base
    {
        /// <summary>
        /// 机构名称
        /// </summary>
        public string groupName { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 站点id
        /// </summary>
        [Required]
        public int stationId { get; set; }
    }
}
