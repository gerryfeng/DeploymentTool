using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowHoliday
    {
        public int Id0 { get; set; }
        public int? Daytype { get; set; }
        public string Dayname { get; set; }
        public DateTime? Daydate { get; set; }
        public DateTime? WorktimeMorFrom { get; set; }
        public DateTime? WorktimeMorTo { get; set; }
        public DateTime? WorktimeAftFrom { get; set; }
        public DateTime? WorktimeAftTo { get; set; }
        public DateTime? WorktimeEveFrom { get; set; }
        public DateTime? WorktimeEveTo { get; set; }
        public int? Isdefaulttime { get; set; }
        public string Remark { get; set; }
    }
}
