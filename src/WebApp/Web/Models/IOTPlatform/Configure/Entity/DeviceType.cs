using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Configure.Entity
{
    [Table("配置_物联设备类型配置表")]
    public class DeviceType
    {

        [Column("ID")]
        public int ID { get; set; }

        [Column("设备类型")]
        public string Type { get; set; }

        /// <summary>
        ///  FTypeName
        /// </summary>
        [Column("父类型名称")]
        [Display(Name = "父类型名称")]
        public string FTypeName { get; set; }

        /// <summary>
        ///  Dimonsion
        /// </summary>
        [Column("分组名称")]
        [Display(Name = "分组名称")]
        public string GroupName { get; set; }


        [Column("地址方案名")]
        [Display(Name = "地址方案名")]
        public string ? AddressName { get; set; }
    }
}
