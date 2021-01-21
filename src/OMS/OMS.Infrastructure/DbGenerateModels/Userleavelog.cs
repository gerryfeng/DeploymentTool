using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Userleavelog
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public DateTime? Datestart { get; set; }
        public DateTime? Dateend { get; set; }
        public int? Leavetypeid { get; set; }
        public string Remark { get; set; }
    }
}
