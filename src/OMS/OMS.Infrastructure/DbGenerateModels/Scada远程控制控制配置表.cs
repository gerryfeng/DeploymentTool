using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Scada远程控制控制配置表
    {
        public int Id { get; set; }
        public int? SensorId { get; set; }
        public double? 阈值上限 { get; set; }
        public double? 阈值下限 { get; set; }
    }
}
