using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivGisgatherElement
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public string ElemId { get; set; }
        public string Operation { get; set; }
        public string GeomType { get; set; }
        public string OldGeom { get; set; }
        public string OldAtt { get; set; }
        public string NewGeom { get; set; }
        public string NewAtt { get; set; }
        public string LayerName { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string Images { get; set; }
        public string State { get; set; }
        public int? Exist { get; set; }
    }
}
