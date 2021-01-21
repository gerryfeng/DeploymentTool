using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备匹配分析结论表
    {
        public int Id { get; set; }
        public string 设备类型 { get; set; }
        public string 设备型号 { get; set; }
        public string 过载流量 { get; set; }
        public int? 百分比 { get; set; }
        public string 结论 { get; set; }
        public string 联系方式 { get; set; }
        public string Url { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
    }
}
