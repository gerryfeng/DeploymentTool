using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class SvcLog
    {
        public long Lid { get; set; }
        public string Username { get; set; }
        public DateTime? Time { get; set; }
        public string Contract { get; set; }
        public string Operationname { get; set; }
        public string Ipaddress { get; set; }
        public string Browserinfo { get; set; }
        public int Elapsedmillisecond { get; set; }
        public int Throughput { get; set; }
        public string Function { get; set; }
        public string Service { get; set; }
        public string Port { get; set; }
    }
}
