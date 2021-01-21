using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowLabel
    {
        public int Id0 { get; set; }
        public int? 用户id { get; set; }
        public string 类型名称 { get; set; }
        public string 类型颜色 { get; set; }
        public string 图片路径 { get; set; }
        public string 备注 { get; set; }
    }
}
