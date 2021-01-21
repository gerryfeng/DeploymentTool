using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Especialarea
    {
        public int Eareaid { get; set; }
        public int? EventId { get; set; }
        public string Areatype { get; set; }
        public string Areaworktype { get; set; }
        public string EareaName { get; set; }
        public string EareaDesc { get; set; }
        public string Earearange { get; set; }
        public int? Geomtype { get; set; }
        public int? CheckerId { get; set; }
        public DateTime? Recordtime { get; set; }
        public string CheckerName { get; set; }
    }
}
