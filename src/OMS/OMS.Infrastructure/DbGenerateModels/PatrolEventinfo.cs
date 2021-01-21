using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolEventinfo
    {
        public int Id { get; set; }
        public int? PlanId { get; set; }
        public int? EventTypeid { get; set; }
        public string EventRoad { get; set; }
        public string ReportName { get; set; }
        public int? CheckerId { get; set; }
        public string EventDesc { get; set; }
        public string CheckerGroup { get; set; }
        public string EventResult { get; set; }
        public string EventCommit { get; set; }
        public string EventPosition { get; set; }
        public DateTime? Happentime { get; set; }
        public DateTime? Endtime { get; set; }
        public byte[] Firstpics { get; set; }
        public byte[] Firstmedia { get; set; }
        public byte[] Backpics { get; set; }
        public byte[] Backmedia { get; set; }
        public string Caseno { get; set; }
        public string Pipeid0 { get; set; }
        public string Tablename { get; set; }
    }
}
