using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaAlertHistory
    {
        public int Id { get; set; }
        public string SensorId { get; set; }
        public int AlertFlag { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Status { get; set; }
        public string Feedback { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public int? FeedbackId { get; set; }
        public double? Pv { get; set; }
    }
}
