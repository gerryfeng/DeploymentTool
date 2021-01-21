﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 数据历史水源井
    {
        public DateTime? 更新时间 { get; set; }
        public DateTime? 采集时间 { get; set; }
        public string 设备编码 { get; set; }
        public int? 是否在线 { get; set; }
        public int? 是否报警 { get; set; }
        public float? 在线时长 { get; set; }
        public float? 离线时长 { get; set; }
        public float? 报警时长 { get; set; }
    }
}
