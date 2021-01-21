using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.ApplicationCore
{
    [Table("SYSPURVIEWTYPE")]
    public class SysPurViewType:BaseEntity
    {
        [Key]
        public int Id0 { get; set; }
        public string Purviewname { get; set; }
        public string Friendlyname { get; set; }
        public int? Sysdef { get; set; }
        public string Remark { get; set; }
    }
}
