using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.Configure
{
    public class ExportModel
    {

        [Column("ID")]
        public int ID { get; set; }

        [Column("模型名称")]
        public string Name { get; set; }

        [Column("模型存储路径")]
        public string ModelPath { get; set; }

        [Column("类型名称")]
        public string TypeName { get; set; }

        [Column("模型文件")]
        public byte[] ModelFile { get; set; }

    }
}
