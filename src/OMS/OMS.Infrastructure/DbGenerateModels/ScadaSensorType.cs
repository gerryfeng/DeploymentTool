using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaSensorType
    {
        public int Id { get; set; }
        public int? DataKindId { get; set; }
        public string Name { get; set; }
        public int? DecimalPoint { get; set; }
        public string Unit { get; set; }
        public string Style { get; set; }
        public string Format { get; set; }
        public string ShortName { get; set; }
        public string 备注 { get; set; }
    }
}
