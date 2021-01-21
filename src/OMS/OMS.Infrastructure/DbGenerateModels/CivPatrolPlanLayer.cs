using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolPlanLayer
    {
        public int Id { get; set; }
        public int? PlanId { get; set; }
        public int? TaskId { get; set; }
        public int? LayerId { get; set; }
        public string Fields { get; set; }
    }
}
