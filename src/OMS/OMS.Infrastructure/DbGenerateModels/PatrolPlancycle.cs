using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolPlancycle
    {
        public int Id { get; set; }
        public string Plancycle { get; set; }
        public int Timelen { get; set; }
        public string Timeunit { get; set; }
        public int? Times { get; set; }
        public int? Isexist { get; set; }
    }
}
