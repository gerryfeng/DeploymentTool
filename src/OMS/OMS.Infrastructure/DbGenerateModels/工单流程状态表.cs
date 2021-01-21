using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单流程状态表
    {
        public long Id { get; set; }
        public string 事件编号 { get; set; }
        public string 工单编号 { get; set; }
        public string 事件名称 { get; set; }
        public string 流程名称 { get; set; }
        public DateTime? 开始时间 { get; set; }
        public DateTime? 结束时间 { get; set; }
        public int? 是否结束 { get; set; }
        public string 更新状态 { get; set; }
        public DateTime? 更新时间 { get; set; }
        public int? 工单是否反馈 { get; set; }
    }
}
