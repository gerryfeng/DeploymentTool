using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单步骤反馈配置表
    {
        public long Id { get; set; }
        public string 流程名称 { get; set; }
        public string 节点名称 { get; set; }
        public string 反馈表名 { get; set; }
        public string 字段集 { get; set; }
        public string 步骤名称 { get; set; }
        public int? 步骤序号 { get; set; }
    }
}
