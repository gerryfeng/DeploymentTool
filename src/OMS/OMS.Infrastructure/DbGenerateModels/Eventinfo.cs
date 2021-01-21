using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Eventinfo
    {
        public int EventId { get; set; }
        public string EventSource { get; set; }
        public string EventSid { get; set; }
        public DateTime? ReportTime { get; set; }
        public string Handlevel { get; set; }
        public int EventTypeid { get; set; }
        public string Eventdesc { get; set; }
        public string Eventaddr { get; set; }
        public string Tel { get; set; }
        public int Reporterid { get; set; }
        public string Reporter { get; set; }
        public string Caseno { get; set; }
        public string Patrolposition { get; set; }
    }
}
