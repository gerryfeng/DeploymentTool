using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 报警记录表
    {
        public int Id { get; set; }
        public int 方案id { get; set; }
        public int? 配置id { get; set; }
        public string Code { get; set; }
        public int? SensorId { get; set; }
        public DateTime? 开始时间 { get; set; }
        public DateTime? 结束时间 { get; set; }
        public string 报警值 { get; set; }
        public string 报警限值 { get; set; }
        public string 报警内容 { get; set; }
        public int? 反馈id { get; set; }
        public string 备注 { get; set; }
        public int? 报警等级 { get; set; }
        public string 报警规则 { get; set; }
        public int? 是否删除 { get; set; }
    }
}
