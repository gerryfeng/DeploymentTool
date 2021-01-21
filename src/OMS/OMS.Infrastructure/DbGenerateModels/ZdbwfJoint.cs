using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ZdbwfJoint
    {
        public int Uid { get; set; }
        public int? Stepid { get; set; }
        public int? Userid { get; set; }
        public DateTime? Utime { get; set; }
        public int? Needusers { get; set; }
        public string Isback { get; set; }
        public int? Tonode { get; set; }
        public int? Touser { get; set; }
        public string Allsubuser { get; set; }
    }
}
