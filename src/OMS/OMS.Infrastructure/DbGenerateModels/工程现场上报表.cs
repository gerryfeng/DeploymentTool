using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工程现场上报表
    {
        public long Id { get; set; }
        public string 工单编号 { get; set; }
        public string 施工现场情况 { get; set; }
        public string 现场图片 { get; set; }
        public string 当前进度 { get; set; }
        public string 安全隐患描述 { get; set; }
        public string 上报人 { get; set; }
        public DateTime? 上报时间 { get; set; }
    }
}
