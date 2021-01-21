using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Configure.Entity
{

    [Table("组态_模型表")]
    public class Model
    {

        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("模型名称")]
        [Display(Name = "模型名称")]
        public string Name { get; set; }

        /// <summary>
        ///  Type
        /// </summary>
        [Column("类型名称")]
        [Display(Name = "类型名称")]
        public string TypeName { get; set; }

        /// <summary>
        ///  Dimonsion
        /// </summary>
        [Column("维度")]
        [Display(Name = "维度")]
        public string Dimonsion { get; set; }

        [Column("模型存储路径")]
        [Display(Name = "模型存储路径")]
        public string ModelPath { get; set; }

        [Column("模型长宽高")]
        [Display(Name = "模型长宽高")]
        public string Size { get; set; }

        [Column("图标路径")]
        [Display(Name = "图标路径")]
        public string ImgPath { get; set; }

        [Column("创建日期")]
        [Display(Name = "创建日期")]
        public DateTime ? createTime  { get; set; }

        [Column("创建人")]
        [Display(Name = "创建人")]
        public string people { get; set; }

        [Column("是否删除")]
        [Display(Name = "是否删除")]
        public int IsDelete { get; set; }

        [Column("模型维度关联")]
        [Display(Name = "模型维度关联")]
        public int ? RealModel { get; set; }

        [Column("材质文件路径")]
        [Display(Name = "材质文件路径")]
        public string Material { get; set; }

        [Column("特征")]
        [Display(Name = "特征")]
        public string Features { get; set; }

        [Column("是否编辑")]
        [Display(Name = "是否编辑")]
        public int IsEdit { get; set; }

        [Column("模型文件")]
        [Display(Name = "模型文件")]
        public byte[] ? ModelFile { get; set; }

    }
}
