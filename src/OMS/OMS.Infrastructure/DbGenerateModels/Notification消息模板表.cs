using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Notification消息模板表
    {
        public int Id { get; set; }
        public string 模板类型 { get; set; }
        public string 模板别名 { get; set; }
        public string 模板名称 { get; set; }
        public string 模板编号 { get; set; }
        public string 模板解析规则 { get; set; }
        public string 案例展示 { get; set; }
    }
}
