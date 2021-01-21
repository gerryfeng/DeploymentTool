using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OMS.ApplicationCore
{
    [Table("配置_系统信息表")]
    public class Sys_Configuration:BaseEntity
    {
        [Key]
        public int ID { get; set; }

        [Column("父配置项名称")]
        public string PModuleName { get; set; }

        [Column("配置项名称")]
        public string ModuleName { get; set; }

        [Column("配置项值")]
        public string Value { get; set; }

        [Column("是否启用")]
        public int IsEnable { get; set; }

        [Column("描述")]
        public string Description { get; set; }

        [Column("创建时间")]
        public DateTime CreateTime { get; set; }

        [Column("修改时间")]
        public DateTime ModifyTime { get; set; }
    }

    [Table("配置_地图_复位范围配置表")]
    public class Sys_Map_ResetRangeConfig:BaseEntity
    {
        public int ID { get; set; }

        [Column("机构ID")]
        public int GroupID { get; set; }

        [Column("区域名称")]
        public string AreeName { get; set; }

        [Column("地图范围")]
        public string MapRange { get; set; }
    }
}
