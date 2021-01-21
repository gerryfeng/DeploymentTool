using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolFeedback
    {
        public int Id { get; set; }
        public int? PointId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
