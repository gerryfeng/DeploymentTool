using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowInstanceLog
    {
        public int Id0 { get; set; }
        public string 实例名称 { get; set; }
        public string 活动操作者 { get; set; }
        public int 流程id { get; set; }
        public string 流程名称 { get; set; }
        public int 活动id { get; set; }
        public string 活动名称 { get; set; }
        public int 活动状态 { get; set; }
        public DateTime? 起始时间 { get; set; }
        public DateTime? 结束时间 { get; set; }
        public string 活动异常描述 { get; set; }
        public int 流水号 { get; set; }
    }
}
