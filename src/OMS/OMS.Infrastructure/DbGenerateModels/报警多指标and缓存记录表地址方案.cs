using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 报警多指标and缓存记录表地址方案
    {
        public int 方案id { get; set; }
        public int 配置id { get; set; }
        public string Code { get; set; }
        public int? SensorId { get; set; }
        public DateTime? 开始时间 { get; set; }
        public DateTime? 结束时间 { get; set; }
        public double? 报警值 { get; set; }
        public double? 报警限值 { get; set; }
        public string 报警内容 { get; set; }
        public int? 报警状态 { get; set; }
        public int? 报警等级 { get; set; }
    }
}
