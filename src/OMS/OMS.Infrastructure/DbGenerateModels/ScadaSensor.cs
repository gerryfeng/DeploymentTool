using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaSensor
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int StationId { get; set; }
        public int SensorTypeId { get; set; }
        public bool? TipVisible { get; set; }
        public string ValDesc { get; set; }
        public int? PointAddressId { get; set; }
        public int? 是否同步历史数据 { get; set; }
        public string 二维坐标 { get; set; }
        public int? 是否删除 { get; set; }
        public double? 修正量 { get; set; }
        public int? 采集频度 { get; set; }
        public DateTime? 录入时间 { get; set; }
    }
}
