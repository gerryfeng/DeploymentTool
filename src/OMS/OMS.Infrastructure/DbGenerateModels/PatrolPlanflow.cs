using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolPlanflow
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public string Caseno { get; set; }
        public DateTime? PlanStarttime { get; set; }
        public DateTime? PlanEndtime { get; set; }
        public int Userid { get; set; }
        public string Patrolmanname { get; set; }
        public string PatrolAgency { get; set; }
        public DateTime? AssignTime { get; set; }
        public string Assigner { get; set; }
        public int Isfeedbacked { get; set; }
    }
}
