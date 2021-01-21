using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 巡检阀门记录表
    {
        public long Id { get; set; }
        public string Gis图层 { get; set; }
        public string Gis编号 { get; set; }
        public string 是否完好 { get; set; }
        public string 状态 { get; set; }
        public string 备注 { get; set; }
        public string 拍照 { get; set; }
        public string Gis坐标 { get; set; }
        public string 反馈坐标 { get; set; }
        public string 反馈距离 { get; set; }
    }
}
