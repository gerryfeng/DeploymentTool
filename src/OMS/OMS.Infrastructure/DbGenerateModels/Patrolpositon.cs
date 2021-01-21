using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Patrolpositon
    {
        public int Patrolerid { get; set; }
        public DateTime? Patroltime { get; set; }
        public string Patrolposition { get; set; }
    }
}
