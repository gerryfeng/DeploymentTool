using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{
    public class SketchPadImage
    {

        [Column("ID")]
        public int ID { get; set; }

        [Column("画板图片")]
        public Byte[] bytes { get; set; }
    }
}
