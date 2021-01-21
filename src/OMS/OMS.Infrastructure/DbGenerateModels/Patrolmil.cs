using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Patrolmil
    {
        public int Patrolerid { get; set; }
        public DateTime? Patroltime { get; set; }
        public double? Realdistance { get; set; }
        public int Timelen { get; set; }
        public int Outarea { get; set; }
        public int Errcnt { get; set; }
        public int TaskId { get; set; }
    }
}
