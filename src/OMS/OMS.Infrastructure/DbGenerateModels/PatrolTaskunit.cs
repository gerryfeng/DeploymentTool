using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolTaskunit
    {
        public int TaskId { get; set; }
        public int Planflowid { get; set; }
        public int Userid { get; set; }
        public DateTime? Taskstart { get; set; }
        public DateTime? Taskend { get; set; }
        public string Isarrive { get; set; }
        public string Isfeedback { get; set; }
        public int Arrive { get; set; }
        public int Feedback { get; set; }
        public int Arrivesum { get; set; }
        public int Feedbacksum { get; set; }
        public int? Isread { get; set; }
        public int? Taskstate { get; set; }
    }
}
