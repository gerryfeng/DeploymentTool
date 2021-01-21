using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Userloginfo
    {
        public int Id0 { get; set; }
        public int? Userid { get; set; }
        public string Ip { get; set; }
        public string Line { get; set; }
        public DateTime? Linedate { get; set; }
        public int? Pagesize { get; set; }
        public int? Messagetype { get; set; }
        public string Skin { get; set; }
        public string Funmenuexpand { get; set; }
        public string Att1 { get; set; }
        public string Att2 { get; set; }
        public string Att3 { get; set; }
        public DateTime? Lsloadtime { get; set; }
        public DateTime? Lsofftime { get; set; }
        public double? Hours { get; set; }
        public int? Loadcount { get; set; }
    }
}
