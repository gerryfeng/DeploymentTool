using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaSensorRealTimeTemp
    {
        public string SensorId { get; set; }
        public double Pv { get; set; }
        public DateTime Pt { get; set; }
        public string Date { get; set; }
    }
}
