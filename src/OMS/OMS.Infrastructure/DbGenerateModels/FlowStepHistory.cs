using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowStepHistory
    {
        public int Id0 { get; set; }
        public string 案件编号 { get; set; }
        public string 案件名称 { get; set; }
        public int 流程id { get; set; }
        public int 活动id { get; set; }
        public int 承办人id { get; set; }
        public string 承办意见 { get; set; }
        public DateTime? 承办时间 { get; set; }
        public decimal? 延迟时间 { get; set; }
        public int 流水号 { get; set; }
        public string 备注 { get; set; }
        public int 历史标志 { get; set; }
        public int 现状标志 { get; set; }
        public string 案件状态 { get; set; }
        public string 已办事件 { get; set; }
        public string 保留字段1 { get; set; }
        public string 保留字段2 { get; set; }
        public int? 母流程入口id0 { get; set; }
        public int? 主承办人 { get; set; }
        public string 工作所花时间 { get; set; }
        public int? Prestep { get; set; }
        public int States { get; set; }
        public string Ip { get; set; }
        public int? 督办id { get; set; }
        public int 移交方向 { get; set; }
        public int? 分组id { get; set; }
        public double? 时限 { get; set; }
        public int 会办标志 { get; set; }
        public DateTime? 办结时间 { get; set; }
    }
}
