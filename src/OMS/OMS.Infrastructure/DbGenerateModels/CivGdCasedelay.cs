using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivGdCasedelay
    {
        public long Id { get; set; }
        public long? Caseid { get; set; }
        public string Applyman { get; set; }
        public string Applygroup { get; set; }
        public DateTime? Applytime { get; set; }
        public DateTime? Applyfinishtime { get; set; }
        public string Verifyman { get; set; }
        public string Verifygroup { get; set; }
        public DateTime? Verifytime { get; set; }
        public string State { get; set; }
        public string Reason { get; set; }
    }
}
