using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Worktimeset
    {
        public int Timeid { get; set; }
        public string Timestart { get; set; }
        public string Timeend { get; set; }
        public string Remark { get; set; }
    }
}
