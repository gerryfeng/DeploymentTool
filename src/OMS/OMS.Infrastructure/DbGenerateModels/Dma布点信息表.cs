using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Dma布点信息表
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string 点位名称 { get; set; }
        public string 分区编码 { get; set; }
        public string 点位坐标 { get; set; }
        public string 点位类型 { get; set; }
        public string 管径 { get; set; }
        public string 材质 { get; set; }
        public double? 埋深 { get; set; }
        public string 设备类型 { get; set; }
        public string 点位位置 { get; set; }
        public string 备注 { get; set; }
        public int? 是否删除 { get; set; }
    }
}
