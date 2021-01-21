using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolFbresult
    {
        public int FbResultid { get; set; }
        public int Taskid { get; set; }
        public DateTime? FbTime { get; set; }
        public string FbDesc { get; set; }
        public string FbValue { get; set; }
        public byte[] FbImage { get; set; }
    }
}
