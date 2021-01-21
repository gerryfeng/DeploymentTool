using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivGdWxMaterialBiz
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Spec { get; set; }
        public string Unit { get; set; }
        public string Price { get; set; }
        public string Count { get; set; }
        public string Maker { get; set; }
        public int? Exist { get; set; }
        public string Operator { get; set; }
        public int? OperatorId { get; set; }
        public DateTime? OperateTime { get; set; }
        public int? ProjectId { get; set; }
        public int? CaseId { get; set; }
        public string CaseNo { get; set; }
        public int? MaterialId { get; set; }
        public string MaterialMark { get; set; }
    }
}
