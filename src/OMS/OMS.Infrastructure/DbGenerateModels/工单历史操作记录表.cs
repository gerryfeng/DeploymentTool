using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单历史操作记录表
    {
        public long Id { get; set; }
        public string 工单编号 { get; set; }
        public string 流程名称 { get; set; }
        public string 节点名称 { get; set; }
        public int? 移交方向 { get; set; }
        public string 操作人名称 { get; set; }
        public string 操作人部门 { get; set; }
        public string 操作时间 { get; set; }
        public string 图片 { get; set; }
        public string 录音 { get; set; }
        public string 附件 { get; set; }
        public string 描述 { get; set; }
    }
}
