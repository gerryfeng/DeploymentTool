using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备养护周期表
    {
        public int Id { get; set; }
        public string 养护周期 { get; set; }
        public int? 周期时长 { get; set; }
        public string 周期单位 { get; set; }
        public int? 容忍时长 { get; set; }
        public string 容忍时间单位 { get; set; }
        public int? 是否存在 { get; set; }
    }
}
