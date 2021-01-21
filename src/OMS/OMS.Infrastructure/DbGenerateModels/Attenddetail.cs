using System;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Attenddetail
    {
        public long Id0 { get; set; }
        public DateTime? Nowdate { get; set; }
        public string Groupcode { get; set; }
        public string Username { get; set; }
        public DateTime? Mornintime { get; set; }
        public string Mornislate { get; set; }
        public DateTime? Mornofftime { get; set; }
        public string Mornisleave { get; set; }
        public string Mornisabsence { get; set; }
        public DateTime? Aftintime { get; set; }
        public string Aftislate { get; set; }
        public DateTime? Aftofftime { get; set; }
        public string Aftisleave { get; set; }
        public string Aftisabsence { get; set; }
        public string Isholiday { get; set; }
    }
}
