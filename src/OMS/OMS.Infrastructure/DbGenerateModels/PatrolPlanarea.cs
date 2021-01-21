using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolPlanarea
    {
        public int Id { get; set; }
        public int? Pathid { get; set; }
        public string Areaname { get; set; }
        public string Arearange { get; set; }
        public int? Areatype { get; set; }
        public string Patrolmanid { get; set; }
        public string Parentid { get; set; }
        public int? Isexit { get; set; }
        public int? EquipEntityids { get; set; }
    }
}
