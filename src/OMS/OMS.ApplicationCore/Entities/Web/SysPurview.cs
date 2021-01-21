using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.ApplicationCore
{
    [Table("SYSPURVIEW")]
    public class SysPurview:BaseEntity
    {
        public long Id0 { get; set; }
        public int Resid { get; set; }
        public int? Restype { get; set; }
        public string Rolecode { get; set; }
        public int? Roletype { get; set; }
        public int? Purview { get; set; }
        public string Grantordeny { get; set; }

        public virtual SysMenu SysMenu { get; set; }
        public virtual Flow_Groups Flow_Group { get; set; }
    }
}
