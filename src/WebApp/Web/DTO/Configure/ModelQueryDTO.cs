using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{
    public class ModelQueryDTO
    {

        [Column("ID")]
        public int ID { get; set; }

        [Column("类型名称")]
        public string TypeName { get; set; }

        [Column("模型名称")]
        public string Name { get; set; }

        [Column("图标路径")]
        public string? ImgPath { get; set; }

        [Column("模型存储路径")]
        public string ModelPath { get; set; }

        [Column("模型长宽高")]
        public string? Size { get; set; }

        [Column("维度")]
        public string Dimonsion { get; set; }

        [Column("创建人")]
        public string? people { get; set; }

        [Column("是否删除")]
        public int? IsDelete { get; set; }

        [Column("创建日期")]
        public DateTime? createTime { get; set; }

        [Column("材质文件路径")]
        public string? Material { get; set; }

        [Column("模型维度关联")]
        public int ? RealModel { get; set; }

        [NotMapped]
        public string property { get; set; }

        [NotMapped]
        public List<ModelQueryDTO> children { get; set; }

        public ModelQueryDTO() 
        {
            children = new List<ModelQueryDTO>();
        }

    }
}
