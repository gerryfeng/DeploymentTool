using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolEventreport
    {
        public int Id { get; set; }
        public string EventSource { get; set; }
        public int? AttachedId { get; set; }
        public int? PointId { get; set; }
        public string LayerName { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public int? CategoryId { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string Desciption { get; set; }
        public string Photo { get; set; }
        public int? UserId { get; set; }
        public DateTime? ReportTime { get; set; }
        public string State { get; set; }
        public int? IsExist { get; set; }
    }
}
