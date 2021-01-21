using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单漏点处理工单表
    {
        public long Id { get; set; }
        public string 工单编号 { get; set; }
        public string 现场描述 { get; set; }
        public string 现场图片 { get; set; }
        public string 坐标位置 { get; set; }
        public string 复核意见 { get; set; }
    }
}
