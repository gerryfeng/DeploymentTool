using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.Configure
{
    public class ModelFeatureData
    {
        [Key]
        [Column("ID")]
        public int id { get; set; }

        [Column("模型存储路径")]
        public string file { get; set; }

        [Column("模型名称")]
        public string bfName { get; set; }

        [Column("类型名称")]
        public string type { get; set; }

        [Column("特征")]
        public string? feature { get; set; }

        [Column("维度")]

        public string dimension { get; set; }

        [NotMapped]
        public string list { get; set; }
    }
}
