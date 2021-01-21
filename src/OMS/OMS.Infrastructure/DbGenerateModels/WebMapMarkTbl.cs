using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class WebMapMarkTbl
    {
        public int Id { get; set; }
        public string MarkName { get; set; }
        public string Geometry { get; set; }
        public string GeometryType { get; set; }
        public string Gonghao { get; set; }
        public long? CtreateTime { get; set; }
        public string Symbol { get; set; }
    }
}
