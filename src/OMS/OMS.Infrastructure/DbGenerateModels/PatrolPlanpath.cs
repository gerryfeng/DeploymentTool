using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolPlanpath
    {
        public int Id { get; set; }
        public string Pathname { get; set; }
        public string Pathrange { get; set; }
        public string Pathpoly { get; set; }
    }
}
