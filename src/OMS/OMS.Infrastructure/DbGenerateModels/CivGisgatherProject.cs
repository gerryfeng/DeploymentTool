using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivGisgatherProject
    {
        public int Id { get; set; }
        public int? EventId { get; set; }
        public string EventCode { get; set; }
        public string CaseNo { get; set; }
        public string Type { get; set; }
        public string Range { get; set; }
        public int? FinishFlag { get; set; }
        public DateTime? FinishTime { get; set; }
        public string Status { get; set; }
        public int? Exist { get; set; }
    }
}
