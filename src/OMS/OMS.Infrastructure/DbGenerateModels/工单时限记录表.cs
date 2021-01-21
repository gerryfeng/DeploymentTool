using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单时限记录表
    {
        public long Id { get; set; }
        public long? 规则id { get; set; }
        public string 事件编号 { get; set; }
        public DateTime? 开始时间 { get; set; }
        public DateTime? 预计完成时间 { get; set; }
        public DateTime? 实际完成时间 { get; set; }
        public int? 现状标志 { get; set; }
        public string 工单编号 { get; set; }
    }
}
