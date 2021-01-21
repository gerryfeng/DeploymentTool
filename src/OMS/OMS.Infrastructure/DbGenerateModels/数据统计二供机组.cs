using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 数据统计二供机组
    {
        public long Id { get; set; }
        public string 设备编码 { get; set; }
        public string 指标名称 { get; set; }
        public DateTime? 更新时间 { get; set; }
        public string 统计周期 { get; set; }
        public string 统计时间 { get; set; }
        public string 统计类型 { get; set; }
        public double? 统计值 { get; set; }
        public DateTime? 统计值发生时间 { get; set; }
        public string 采集编码 { get; set; }
        public string 采集协议 { get; set; }
        public int? 顺序 { get; set; }
    }
}
