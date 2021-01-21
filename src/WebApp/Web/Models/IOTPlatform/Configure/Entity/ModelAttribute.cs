using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Configure.Entity
{
    [Table("组态_属性表")]
    public class ModelAttribute
    {

        [Column("ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "属性名称")]
        [Column("属性名称")]
        public string Name { get; set; }


        [Display(Name = "属性类型")]
        [Column("属性类型")]
        public string Type { get; set; }


    }
}
