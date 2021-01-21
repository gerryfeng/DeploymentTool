using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaSensorHistoryTemp
    {
        public string SensorId { get; set; }
        public double Pv { get; set; }
        public DateTime Pt { get; set; }
        public string Date { get; set; }
    }
}
