using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Dma分区表
    {
        public int Id { get; set; }
        public string 分区编码 { get; set; }
        public string 分区名称 { get; set; }
        public int? 分区级别 { get; set; }
        public string 父分区编码 { get; set; }
        public string 分区边界 { get; set; }
        public double? 管线长度 { get; set; }
        public double? 区域面积 { get; set; }
        public double? 目标产销差 { get; set; }
        public double? 目标漏损率 { get; set; }
        public string 区域颜色 { get; set; }
        public string 关注程度 { get; set; }
        public int? 用户总数 { get; set; }
        public string 责任人 { get; set; }
        public string 备注 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int 是否删除 { get; set; }
        public double? 背景漏失流量 { get; set; }
        public int? 瞬流监控 { get; set; }
    }
}
