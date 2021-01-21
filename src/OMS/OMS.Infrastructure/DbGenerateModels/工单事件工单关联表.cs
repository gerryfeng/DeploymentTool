using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单事件工单关联表
    {
        public long Id { get; set; }
        public string 业务类型 { get; set; }
        public string 任务编号 { get; set; }
        public string 事件类型 { get; set; }
        public string 事件编号 { get; set; }
        public string 事件名称 { get; set; }
    }
}
