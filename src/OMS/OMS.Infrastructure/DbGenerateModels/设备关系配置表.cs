using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备关系配置表
    {
        public long Id { get; set; }
        public string 设备名称 { get; set; }
        public string 设备台账表 { get; set; }
        public string 台账字段集 { get; set; }
        public string 台账显示字段集 { get; set; }
        public string 手持台账显示字段集 { get; set; }
        public string Gis图层 { get; set; }
        public string Gis条件 { get; set; }
        public string 父设备名称 { get; set; }
        public string 业务类型 { get; set; }
        public int? 级别 { get; set; }
        public int? 顺序 { get; set; }
    }
}
