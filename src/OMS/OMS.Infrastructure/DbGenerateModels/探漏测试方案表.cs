using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 探漏测试方案表
    {
        public int Id { get; set; }
        public string 方案名称 { get; set; }
        public DateTime? 开始时间 { get; set; }
        public DateTime? 停止时间 { get; set; }
        public string 分区范围 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
        public string 分析模式 { get; set; }
        public double? 漏损量 { get; set; }
        public string 漏损率 { get; set; }
        public string 测试结果 { get; set; }
    }
}
