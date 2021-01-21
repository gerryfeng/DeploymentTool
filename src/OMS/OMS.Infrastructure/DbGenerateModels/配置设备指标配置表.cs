using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 配置设备指标配置表
    {
        public int Id { get; set; }
        public string 设备类型 { get; set; }
        public string 业务指标 { get; set; }
        public string 指标名称 { get; set; }
    }
}
