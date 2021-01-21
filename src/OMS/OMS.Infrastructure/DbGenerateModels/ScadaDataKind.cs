using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaDataKind
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DataType { get; set; }
        public string DataKindCode { get; set; }
        public string ExName { get; set; }
        public string ShortName { get; set; }
        public int? FirstClassIndexOrder { get; set; }
        public int? SecondClassIndexOrder { get; set; }
        public string Style { get; set; }
        public string Format { get; set; }
    }
}
