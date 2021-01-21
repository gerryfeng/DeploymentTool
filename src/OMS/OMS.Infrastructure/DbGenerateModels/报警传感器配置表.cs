using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 报警传感器配置表
    {
        public int Id { get; set; }
        public int 方案id { get; set; }
        public int? SensorId { get; set; }
        public int? 报警等级 { get; set; }
        public DateTime? 生效开始日期 { get; set; }
        public DateTime? 生效结束日期 { get; set; }
        public string 生效开始时间段 { get; set; }
        public string 生效结束时间段 { get; set; }
        public string 取值方式 { get; set; }
        public double? 报警低限 { get; set; }
        public double? 报警高限 { get; set; }
        public double? 报警低低限 { get; set; }
        public double? 报警高高限 { get; set; }
        public double? 固定报警值 { get; set; }
        public int? 是否删除 { get; set; }
    }
}
