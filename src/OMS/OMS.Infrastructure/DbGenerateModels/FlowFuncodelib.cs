using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowFuncodelib
    {
        public int 事件号 { get; set; }
        public int 活动id { get; set; }
        public string 事件名称 { get; set; }
        public string 页面url { get; set; }
        public string Pagetoolcodes { get; set; }
        public int? Formid { get; set; }
        public string 备用1 { get; set; }
        public string 备用2 { get; set; }
    }
}
