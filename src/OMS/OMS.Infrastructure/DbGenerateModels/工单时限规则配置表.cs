using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单时限规则配置表
    {
        public long Id { get; set; }
        public string 流程名称 { get; set; }
        public string 规则名称 { get; set; }
        public string 开始节点 { get; set; }
        public string 结束节点 { get; set; }
        public int? 默认时限 { get; set; }
        public string 时限对应字段 { get; set; }
        public string 超期对应字段 { get; set; }
        public string 时限单位 { get; set; }
    }
}
