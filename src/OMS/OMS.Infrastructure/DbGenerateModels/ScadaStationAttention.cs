using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaStationAttention
    {
        public int Id { get; set; }
        public int? StationId { get; set; }
        public int? UserId { get; set; }
    }
}
