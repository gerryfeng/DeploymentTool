using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 监控二供水箱清洗台账表
    {
        public int Id { get; set; }
        public string 记录编号 { get; set; }
        public DateTime? 清洗日期 { get; set; }
        public double? 水箱容积 { get; set; }
        public string 所属泵房 { get; set; }
        public DateTime? 清洗排水开始时间 { get; set; }
        public DateTime? 清洗排水结束时间 { get; set; }
        public double? 清洗排水持续时间 { get; set; }
        public DateTime? 清洗开始时间 { get; set; }
        public DateTime? 清洗结束时间 { get; set; }
        public double? 清洗持续时间 { get; set; }
        public string 清洗人员 { get; set; }
        public DateTime? 消毒放水开始时间 { get; set; }
        public DateTime? 消毒放水结束时间 { get; set; }
        public double? 消毒放水持续时间 { get; set; }
        public string 消毒用药品名 { get; set; }
        public string 消毒药品配置人 { get; set; }
        public string 消毒药品见证人 { get; set; }
        public string 清洗消毒情况记录 { get; set; }
        public string 水质取样人 { get; set; }
        public string 取样地点 { get; set; }
        public double? 取样数 { get; set; }
        public DateTime? 送检时间 { get; set; }
        public string 送检人 { get; set; }
        public string 取报告人 { get; set; }
        public DateTime? 取报告日期 { get; set; }
        public string 报告编号 { get; set; }
        public string 水质检测结果 { get; set; }
        public string 检测水样单位 { get; set; }
        public string 清洗单位 { get; set; }
        public string 责任人 { get; set; }
        public string 工程主管 { get; set; }
        public string 主任 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
        public string 停水时间 { get; set; }
        public string 消毒药品用量 { get; set; }
        public string 公示现场照片 { get; set; }
        public string 样品性状 { get; set; }
    }
}
