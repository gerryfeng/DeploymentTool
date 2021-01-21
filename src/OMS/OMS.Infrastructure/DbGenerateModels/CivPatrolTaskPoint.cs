using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolTaskPoint
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public int? TaskId { get; set; }
        public string LayerName { get; set; }
        public string GisLayer { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string Position { get; set; }
        public string Geom { get; set; }
        public double? Lenth { get; set; }
        public int? IsArrive { get; set; }
        public int? ArriveMan { get; set; }
        public DateTime? ArriveTime { get; set; }
        public int? IsFeedback { get; set; }
        public int? FeedbackMan { get; set; }
        public DateTime? FeedbackTime { get; set; }
        public int? FeedbackId { get; set; }
        public string Remark { get; set; }
        public int? Class { get; set; }
        public string Remark1 { get; set; }
        public string Remark2 { get; set; }
        public string Remark3 { get; set; }
        public int? IsCheck { get; set; }
        public int? Radius { get; set; }
    }
}
