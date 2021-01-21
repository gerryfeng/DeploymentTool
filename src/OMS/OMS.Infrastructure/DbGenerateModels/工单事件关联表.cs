using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单事件关联表
    {
        public long Id { get; set; }
        public string 父事件名称 { get; set; }
        public string 父事件编号 { get; set; }
        public string 父事件主表 { get; set; }
        public string 子事件名称 { get; set; }
        public string 子事件编号 { get; set; }
        public string 子事件主表 { get; set; }
    }
}
