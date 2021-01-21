using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 监控二供水质检测台账表
    {
        public int Id { get; set; }
        public string 报告编号 { get; set; }
        public string 所属泵房 { get; set; }
        public string 采样位置 { get; set; }
        public string 样品名称 { get; set; }
        public string 取样位置 { get; set; }
        public string 样品种类 { get; set; }
        public string 检验类别 { get; set; }
        public string 检测单位 { get; set; }
        public string 检测人 { get; set; }
        public DateTime? 送样日期 { get; set; }
        public DateTime? 检测日期 { get; set; }
        public DateTime? 报告日期 { get; set; }
        public string 检测结果 { get; set; }
        public string 检测报告 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
        public string 委托单位 { get; set; }
        public string 委方地址 { get; set; }
        public string 委托日期 { get; set; }
        public string 来样方式 { get; set; }
        public string 采样日期 { get; set; }
        public string 收样日期 { get; set; }
        public string 评价依据 { get; set; }
        public string 检测结论 { get; set; }
        public string 样品性状 { get; set; }
        public string 公示现场照片 { get; set; }
    }
}
