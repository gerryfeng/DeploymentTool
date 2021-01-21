using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备养护关键点
    {
        public int Id { get; set; }
        public string 坐标 { get; set; }
        public int? 区域id { get; set; }
        public string 区域名称 { get; set; }
    }
}
