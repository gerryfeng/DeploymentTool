using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备养护任务模板表
    {
        public long Id { get; set; }
        public long? 计划id { get; set; }
        public string 计划类型 { get; set; }
        public string 任务编号 { get; set; }
        public DateTime? 开始时间 { get; set; }
        public DateTime? 结束时间 { get; set; }
        public DateTime? 最迟完成时间 { get; set; }
        public int? 审核id { get; set; }
        public string 审核状态 { get; set; }
        public string 养护人id { get; set; }
        public string 任务养护人 { get; set; }
        public int? 是否送审 { get; set; }
        public int? 是否完成 { get; set; }
        public DateTime? 完成时间 { get; set; }
        public string 业务名称 { get; set; }
        public int? 是否存在 { get; set; }
        public DateTime? 延期时间 { get; set; }
        public string 延期原因 { get; set; }
        public string 延期人 { get; set; }
        public DateTime? 退单时间 { get; set; }
        public string 退单原因 { get; set; }
        public string 退单人 { get; set; }
        public string 计划养护类型 { get; set; }
        public string 养护类型 { get; set; }
        public long? 反馈id { get; set; }
        public string 反馈人 { get; set; }
        public string 所属站点 { get; set; }
    }
}
