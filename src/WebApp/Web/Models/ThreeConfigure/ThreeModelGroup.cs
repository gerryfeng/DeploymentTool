using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.ThreeConfigure
{
    [Table("三维组态模型类型表")]
    public class ThreeModelGroup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "bigint")]
        public long ID { get; set; }

        [Column("名称", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("编号", TypeName = "varchar(64)")]
        public string Code { get; set; }

        [Column("AttributeIDs", TypeName = "varchar(max)")]
        public string AttributeIDs { get; set; }

        [Column("创建人", TypeName = "varchar(64)")]
        public string CreateUser { get; set; }

        [Column("创建时间", TypeName = "datetime(64)")]
        public DateTime CreateTime { get; set; }
    }


}
