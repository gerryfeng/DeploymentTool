using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Holidaytbl
    {
        public int Id { get; set; }
        public DateTime? Datestart { get; set; }
        public DateTime? Dateend { get; set; }
        public string Remark { get; set; }
        public string Holidaytype { get; set; }
    }
}
