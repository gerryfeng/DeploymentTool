using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 维修处理反馈表
    {
        public long Id { get; set; }
        public string 工单编号 { get; set; }
        public string 现场照片 { get; set; }
        public string 现场录音 { get; set; }
        public string 现场描述 { get; set; }
    }
}
