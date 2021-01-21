using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.ThreeConfigure
{
    [Table("三维组态场景表")]
    public class ThreeSketch
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "bigint")]
        public long ID { get; set; }


        [Column("名称", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("json", TypeName = "varchar(max)")]
        public string SceneInfo { get; set; }

    }
}
