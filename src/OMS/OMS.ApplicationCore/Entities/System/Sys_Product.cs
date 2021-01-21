using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OMS.ApplicationCore
{
    [Table("配置_系统产品表")]
    public class Sys_Product:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Column("应用环境")]
        public string Environment { get; set; }

        [Column("应用名称")]
        public string ProductName { get; set; }

        [Column("启动Url")]
        public string StartUrl { get; set; }

        [Column("产品别名")]
        public string ProductAlias { get; set; }

        [Column("默认配置")]
        public string DefaultSetting { get; set; }
    }
}
