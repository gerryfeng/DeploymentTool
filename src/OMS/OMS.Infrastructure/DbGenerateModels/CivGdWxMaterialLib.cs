using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivGdWxMaterialLib
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Spec { get; set; }
        public string Unit { get; set; }
        public string Price { get; set; }
        public string Count { get; set; }
        public DateTime? SurePriceTime { get; set; }
        public string Maker { get; set; }
        public int? Exist { get; set; }
        public string MaterialMark { get; set; }
        public string Operator { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public string SSubType { get; set; }
        public DateTime? SPruduceTime { get; set; }
        public string SQualityLevel { get; set; }
        public string SUseDuration { get; set; }
        public string SMakerQualificaton { get; set; }
        public string SMakerMark { get; set; }
    }
}
