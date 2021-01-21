using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单事件流程配置表
    {
        public long Id { get; set; }
        public string 业务类型 { get; set; }
        public string 事件名称 { get; set; }
        public string 流程名称 { get; set; }
        public string 流程权限 { get; set; }
        public int? 显示顺序 { get; set; }
    }
}
