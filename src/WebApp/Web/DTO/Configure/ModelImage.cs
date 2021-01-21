using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{
    public class ModelImage
    {
        [Column("ID")]
        public int ID { get; set; }

        [Column("模型文件")]
        public Byte[] bytes { get; set; }
    }
}
