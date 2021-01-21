using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 数据实时二供泵房
    {
        public int Id { get; set; }
        public string 设备编码 { get; set; }
        public DateTime? 更新时间 { get; set; }
        public DateTime? 采集时间 { get; set; }
        public int? 是否在线 { get; set; }
        public DateTime? 上线时间 { get; set; }
        public float? 在线时长 { get; set; }
        public DateTime? 离线时间 { get; set; }
        public float? 离线时长 { get; set; }
        public int? 是否报警 { get; set; }
        public string 当前报警 { get; set; }
        public float? 报警时长 { get; set; }
        public float? 进水压力 { get; set; }
        public float? 出水瞬时流量 { get; set; }
        public float? 今日供水量 { get; set; }
        public float? 今日用电量 { get; set; }
        public float? 出水累计流量 { get; set; }
        public float? 累计电量 { get; set; }
        public float? 余氯 { get; set; }
        public float? 浊度 { get; set; }
        public float? PH { get; set; }
        public float? _1水箱液位 { get; set; }
        public float? _2水箱液位 { get; set; }
        public string 采集编码 { get; set; }
        public string 采集协议 { get; set; }
        public int? 顺序 { get; set; }
    }
}
