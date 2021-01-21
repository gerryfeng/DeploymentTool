using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 巡检关键点记录表
    {
        public long? Id { get; set; }
        public string Gis图层 { get; set; }
        public string Gis编号 { get; set; }
        public string 关键点名称 { get; set; }
        public string 关键点状态 { get; set; }
        public string 备注 { get; set; }
        public string 拍照 { get; set; }
        public string Gis坐标 { get; set; }
        public string 反馈坐标 { get; set; }
        public string 反馈距离 { get; set; }
    }
}
