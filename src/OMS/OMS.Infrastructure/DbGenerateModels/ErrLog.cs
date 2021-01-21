using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ErrLog
    {
        public long Id { get; set; }
        public string Machinename { get; set; }
        public string Hostname { get; set; }
        public string Assemblyname { get; set; }
        public string Filename { get; set; }
        public int Linenumber { get; set; }
        public string Typename { get; set; }
        public string Memberaccessed { get; set; }
        public DateTime? Time { get; set; }
        public string Exceptionname { get; set; }
        public string Exceptionmessage { get; set; }
        public string Providedfault { get; set; }
        public string Providedmessage { get; set; }
        public string Event { get; set; }
    }
}
