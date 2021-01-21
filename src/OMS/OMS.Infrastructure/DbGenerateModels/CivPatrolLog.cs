using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolLog
    {
        public long Id { get; set; }
        public string 任务编号 { get; set; }
        public string 上报日期 { get; set; }
        public string 日志描述 { get; set; }
        public string 填报人员 { get; set; }
    }
}
