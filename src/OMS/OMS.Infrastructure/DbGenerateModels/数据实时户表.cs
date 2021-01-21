﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 数据实时户表
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
        public float? 户表读数 { get; set; }
        public DateTime? 抄表日期 { get; set; }
        public string 抄表年月 { get; set; }
        public double? 站号 { get; set; }
        public float? Gprs电压 { get; set; }
        public float? 瞬时流量 { get; set; }
        public float? 水表电压 { get; set; }
        public float? 进水压力 { get; set; }
        public float? 正累计流量 { get; set; }
        public float? 今日水量 { get; set; }
        public string 采集编码 { get; set; }
        public string 采集协议 { get; set; }
        public int? 顺序 { get; set; }
    }
}
