using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ValveRecord
    {
        public int Id0 { get; set; }
        public string 记录编号 { get; set; }
        public DateTime? 开启时间 { get; set; }
        public DateTime? 关闭时间 { get; set; }
        public string 系统中的开关状态 { get; set; }
        public string 需要更新启闭状态 { get; set; }
        public string 操作人员 { get; set; }
        public string 目前状况 { get; set; }
        public string 操作原因 { get; set; }
        public string 井内情况 { get; set; }
        public string 备注 { get; set; }
        public string 图层名称 { get; set; }
        public string 阀门编号 { get; set; }
    }
}
