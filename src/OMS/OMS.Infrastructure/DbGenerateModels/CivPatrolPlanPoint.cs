using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolPlanPoint
    {
        public int Id { get; set; }
        public int? PlanId { get; set; }
        public string LayerName { get; set; }
        public string GisLayer { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string Position { get; set; }
        public string Remark { get; set; }
    }
}
