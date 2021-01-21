using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowCaseinfo
    {
        public string 案件编号 { get; set; }
        public string 案件名称 { get; set; }
        public int 流程id { get; set; }
        public DateTime? 开始时间 { get; set; }
        public DateTime? 办结时间 { get; set; }
        public double? 案件时限 { get; set; }
        public int 历史标志 { get; set; }
        public int 状态标志 { get; set; }
        public int 回退总次数 { get; set; }
        public int 环节回退最大次数 { get; set; }
        public int 挂起次数 { get; set; }
        public int 会办次数 { get; set; }
        public string 申请单位 { get; set; }
        public string 联系方式 { get; set; }
    }
}
