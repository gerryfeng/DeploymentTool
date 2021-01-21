using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowOsfuncodelib
    {
        public string 事件号 { get; set; }
        public int 活动id { get; set; }
        public string 功能名称 { get; set; }
        public string 对象来源类型 { get; set; }
        public int? 对象来源活动 { get; set; }
        public int? 优先级 { get; set; }
    }
}
