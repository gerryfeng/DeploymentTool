using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivGdWxFeedback
    {
        public long Id { get; set; }
        public long? Caseid { get; set; }
        public string 处理状态 { get; set; }
        public string 上报人id { get; set; }
        public string 上报人 { get; set; }
        public string 上报人部门 { get; set; }
        public DateTime? 上报时间 { get; set; }
        public int? 分派人员id { get; set; }
        public string 分派人员 { get; set; }
        public string 分派部门 { get; set; }
        public DateTime? 分派时间 { get; set; }
        public DateTime? 预计完成时间 { get; set; }
        public DateTime? 延期完成时间 { get; set; }
        public int? 维修人员id { get; set; }
        public string 维修人员 { get; set; }
        public string 维修部门 { get; set; }
        public DateTime? 阅单时间 { get; set; }
        public DateTime? 接单时间 { get; set; }
        public DateTime? 到场时间 { get; set; }
        public DateTime? 维修时间 { get; set; }
        public DateTime? 修复时间 { get; set; }
        public int? 审核人员id { get; set; }
        public string 审核人员 { get; set; }
        public string 审核部门 { get; set; }
        public DateTime? 审核时间 { get; set; }
    }
}
