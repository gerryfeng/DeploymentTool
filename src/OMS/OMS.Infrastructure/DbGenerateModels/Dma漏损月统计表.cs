using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Dma漏损月统计表
    {
        public int Id { get; set; }
        public string 分区编码 { get; set; }
        public string 统计时间 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
        public string 指标名称 { get; set; }
        public double? 统计值 { get; set; }
    }
}
