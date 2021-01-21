using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaSensorRealTime
    {
        public string SensorId { get; set; }
        public double LastValue { get; set; }
        public DateTime LastTime { get; set; }
    }
}
