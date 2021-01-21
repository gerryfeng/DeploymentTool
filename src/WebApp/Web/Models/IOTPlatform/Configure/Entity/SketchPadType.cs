using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Configure.Entity
{
    [Table("组态_画板类型表")]
    public class SketchPadType
    {

        [Column("ID")]
        public int ID { get; set; }

        [Column("名称")]
        [Required(ErrorMessage ="画板类型名称不能为空")]
        public string Name { get; set; }

        [Column("RoleCode")]
        [Required(ErrorMessage = "画板类型标识不能为空")]
        public string? Code { get; set; }

        [Column("创建时间")]
        public DateTime? CreateTime { get; set; }


    }
}
