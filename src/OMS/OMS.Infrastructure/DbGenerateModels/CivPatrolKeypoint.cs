using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolKeypoint
    {
        public int Id { get; set; }
        public string Geometry { get; set; }
        public int? AreaId { get; set; }
        public string AreaName { get; set; }
        public int? Class { get; set; }
        public string LayerName { get; set; }
        public string Remark { get; set; }
    }
}
