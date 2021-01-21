using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaAlertValue
    {
        public int Id { get; set; }
        public int AlertId { get; set; }
        public string ReferValue { get; set; }
        public double? Value { get; set; }
        public int? AlertLevel { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ValueType { get; set; }
        public int? 是否删除 { get; set; }
    }
}
