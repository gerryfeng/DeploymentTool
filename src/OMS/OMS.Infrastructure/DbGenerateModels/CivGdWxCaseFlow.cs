using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivGdWxCaseFlow
    {
        public long Id { get; set; }
        public string Caseno { get; set; }
        public long? Caseid { get; set; }
        public DateTime? Createtime { get; set; }
        public DateTime? Endtime { get; set; }
        public int? Finishflag { get; set; }
    }
}
