using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolArea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathPolygon { get; set; }
        public string AreaPolygon { get; set; }
        public int? AreaType { get; set; }
        public string Station { get; set; }
        public string UserIds { get; set; }
        public string UserNames { get; set; }
        public int? ParentId { get; set; }
        public int? IsExist { get; set; }
        public double? Area { get; set; }
    }
}
