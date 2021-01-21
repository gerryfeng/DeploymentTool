using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单维修处理工单表
    {
        public long Id { get; set; }
        public string 工单编号 { get; set; }
        public string 维修内容 { get; set; }
        public DateTime? 维修时间 { get; set; }
        public string 现场图片 { get; set; }
        public string 审核意见 { get; set; }
        public DateTime? 审核时间 { get; set; }
        public string 派单信息 { get; set; }
        public string 处理紧急程度 { get; set; }
        public string 处理时限 { get; set; }
        public string 建议处理方法 { get; set; }
        public DateTime? 接单时间 { get; set; }
        public string 接单描述 { get; set; }
        public DateTime? 到场时间 { get; set; }
        public string 到场描述 { get; set; }
        public string 处理结果 { get; set; }
        public string 完工照片 { get; set; }
        public string 备注 { get; set; }
    }
}
