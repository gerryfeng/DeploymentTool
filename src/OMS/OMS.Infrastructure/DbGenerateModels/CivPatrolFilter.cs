using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolFilter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LayerName { get; set; }
        public string LayerFilter { get; set; }
        public int? IsExist { get; set; }
    }
}
