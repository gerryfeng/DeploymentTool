using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{
    public class SketchPadJson
    {
        [Column("ID")]
        public int ID { get; set; }

        [Column("画板名称")]
        public string Name { get; set; }

        [Column("热度")]
        public int ? Heat { get; set; }

        [Column("画板Json")]
        public Byte[] bytes { get; set; }
    }
}
