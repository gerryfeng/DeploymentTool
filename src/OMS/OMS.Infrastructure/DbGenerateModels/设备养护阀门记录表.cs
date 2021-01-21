using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备养护阀门记录表
    {
        public int Id { get; set; }
        public string 规格型号 { get; set; }
        public string 材质 { get; set; }
        public string 阀门类型 { get; set; }
        public string 使用状态 { get; set; }
        public string 到场拍照 { get; set; }
        public string 结束拍照 { get; set; }
        public string 维护耗材 { get; set; }
        public string Gis图层 { get; set; }
        public string Gis编号 { get; set; }
        public string 备注 { get; set; }
        public DateTime? 到场时间 { get; set; }
        public string 反馈坐标 { get; set; }
    }
}
