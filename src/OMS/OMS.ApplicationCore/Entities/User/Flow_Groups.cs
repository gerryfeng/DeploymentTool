using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.ApplicationCore
{
    [Table("FLOW_GROUPS")]
    public class Flow_Groups:BaseEntity
    {
        public Flow_Groups()
        {
            UserRoles = new Collection<Flow_User_Role>();
            SysPurviews = new Collection<SysPurview>();
        }

        [Key]
        public int 机构ID { get; set; }

        public string 名称 { get; set; }
        public int 类型 { get; set; }
        public string 编码 { get; set; }

        public string 描述 { get; set; }
        public int 级别 { get; set; }
        public string 备注 { get; set; }

        public string PASSWORD { get; set; }
        public int INDEXORDER { get; set; }
        public string 行政区划 { get; set; }

        public int? 主管人 { get; set; }
        public string 城市 { get; set; }
        public string ECODE { get; set; }

        public string VISIBLE { get; set; }
        public string 功能访问规则 { get; set; }
        public string 数据访问规则 { get; set; }

        public virtual Collection<Flow_User_Role> UserRoles { get; set; }

        public virtual Collection<SysPurview> SysPurviews { get; set; }
    }
}
