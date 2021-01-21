using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowActivityPara
    {
        public int 活动id { get; set; }
        public string 事件号 { get; set; }
        public int 参数id { get; set; }
        public string 参数名称 { get; set; }
        public string 参数类型 { get; set; }
        public string 参数方向 { get; set; }
        public string 参数值来源类型 { get; set; }
        public string 参数值来源 { get; set; }
    }
}
