using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Configure.Entity
{

    [Table("组态_模型信息表")]
    public class ModelInformation
    {
        [Column("ID")]
        public int ID { get; set; }

        [Column("模型名称")]
        public string Name { get; set; }


        [Column("属性ID")]
        public int AttributeID { get; set; }


        [Display(Name = "VALUE")]
        [Column("VALUE")]
        public string VALUE { get; set; }


        [Display(Name = "维度")]
        [Column("维度")]
        public string Dimonsion { get; set; }
        

    }
}
