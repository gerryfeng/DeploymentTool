using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Syspurview
    {
        public long Id0 { get; set; }
        public int Resid { get; set; }
        public int? Restype { get; set; }
        public string Rolecode { get; set; }
        public int? Roletype { get; set; }
        public int? Purview { get; set; }
        public string Grantordeny { get; set; }

        public virtual Sysmenutree Res { get; set; }
        public virtual FlowGroup RolecodeNavigation { get; set; }
    }
}
