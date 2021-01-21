using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolCycle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CycleLen { get; set; }
        public string Unit { get; set; }
        public int? Frequency { get; set; }
        public int? IsExist { get; set; }
    }
}
