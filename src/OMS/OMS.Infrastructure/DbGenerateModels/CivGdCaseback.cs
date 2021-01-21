using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivGdCaseback
    {
        public long Id { get; set; }
        public long? Caseid { get; set; }
        public string Activename { get; set; }
        public string Backman { get; set; }
        public string Backmandepart { get; set; }
        public DateTime? Backtime { get; set; }
        public string Reason { get; set; }
    }
}
