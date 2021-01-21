using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolPlantbl
    {
        public int Id { get; set; }
        public string Planname { get; set; }
        public int? Plantypeid { get; set; }
        public int? Areaid { get; set; }
        public int? Pathid { get; set; }
        public int? EquipEntityids { get; set; }
        public int? PipeEntityids { get; set; }
        public int? Isfeedback { get; set; }
        public string PlanMaker { get; set; }
        public DateTime? PlanCreatetime { get; set; }
        public int Plancycleid { get; set; }
        public int? Isopen { get; set; }
        public int? Istemp { get; set; }
        public int? Isexit { get; set; }
        public int? PlanMakerid { get; set; }
    }
}
