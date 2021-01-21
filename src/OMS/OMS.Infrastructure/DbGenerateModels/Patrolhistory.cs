using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Patrolhistory
    {
        public int? Patrolerid { get; set; }
        public DateTime? Patroltime { get; set; }
        public string Tracestr { get; set; }
        public decimal? Tracedistance { get; set; }
        public decimal? Lastx { get; set; }
        public decimal? Lasty { get; set; }
        public int? Isover { get; set; }
        public int? Errortype { get; set; }
    }
}
