using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowCasemeeting
    {
        public int Id0 { get; set; }
        public string Caseno { get; set; }
        public int? Activeid { get; set; }
        public int? Submituserid { get; set; }
        public DateTime? Starttime { get; set; }
        public int? State { get; set; }
        public string Resultopinion { get; set; }
        public int? Chargemanid { get; set; }
        public DateTime? Endtime { get; set; }
    }
}
