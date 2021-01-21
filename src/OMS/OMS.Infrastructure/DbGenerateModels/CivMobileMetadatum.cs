using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivMobileMetadatum
    {
        public int Id { get; set; }
        public string MapName { get; set; }
        public string LayerName { get; set; }
        public int? IsEquipment { get; set; }
        public string HighlightField { get; set; }
        public string FieldList { get; set; }
    }
}
