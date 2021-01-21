using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowProcessPara
    {
        public int 流程id { get; set; }
        public int 参数id { get; set; }
        public string 参数名称 { get; set; }
        public string 参数类型 { get; set; }
        public string 参数方向 { get; set; }
        public string 默认值 { get; set; }
        public string 页面元素 { get; set; }
    }
}
