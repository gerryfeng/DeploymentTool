using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备巡维保计划表
    {
        public int Id { get; set; }
        public string 计划编码 { get; set; }
        public string 模板名称 { get; set; }
        public DateTime? 下次计划开始时间 { get; set; }
        public DateTime? 下次计划结束时间 { get; set; }
        public string 执行人 { get; set; }
        public string 设备编码 { get; set; }
        public DateTime? 上次完成时间 { get; set; }
    }
}
