using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolPlantype
    {
        public int Id { get; set; }
        public int Pid { get; set; }
        public string Plantype { get; set; }
        public string Layerfilter { get; set; }
        public int? Exist { get; set; }
    }
}
