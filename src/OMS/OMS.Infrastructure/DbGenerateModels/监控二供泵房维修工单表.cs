using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 监控二供泵房维修工单表
    {
        public long Id { get; set; }
        public string 工单编号 { get; set; }
        public string 处理紧急程度 { get; set; }
        public string 处理时限 { get; set; }
        public string 建议处理方法 { get; set; }
        public DateTime? 接单时间 { get; set; }
        public string 接单描述 { get; set; }
        public string 到场照片 { get; set; }
        public string 到场描述 { get; set; }
        public DateTime? 到场时间 { get; set; }
        public string 到场录音 { get; set; }
        public string 维修方式 { get; set; }
        public string 维修图片 { get; set; }
        public string 维修描述 { get; set; }
        public DateTime? 维修时间 { get; set; }
        public DateTime? 预计维修结束时间 { get; set; }
        public string 维修录音 { get; set; }
        public string 维修人 { get; set; }
        public DateTime? 完工时间 { get; set; }
        public string 完工图片 { get; set; }
        public string 完工录音 { get; set; }
        public string 完工描述 { get; set; }
        public string 是否完成维修 { get; set; }
        public string 审核意见 { get; set; }
        public string 现场核实人 { get; set; }
        public string 事件类型 { get; set; }
        public string 事件内容 { get; set; }
    }
}
