using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.Configure
{
    public class ExportSkpad
    {
        [Column("ID")]
        public int ID { get; set; }

        [Column("画板名称")]
        public string Name { get; set; }

        [Column("画板图片")]
        public Byte[]? images { get; set; }

        [Column("画板Json")]
        public Byte[] bytes { get; set; }
    }
}
