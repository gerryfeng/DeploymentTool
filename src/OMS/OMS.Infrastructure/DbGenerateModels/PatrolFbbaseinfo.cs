using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class PatrolFbbaseinfo
    {
        public int Id { get; set; }
        public int Plantypeid { get; set; }
        public string FbDesc { get; set; }
        public string FbType { get; set; }
        public int Istrigger { get; set; }
        public string TrigCondition { get; set; }
        public string EventDesc { get; set; }
        public string FbGroup { get; set; }
        public int? Must { get; set; }
        public int? Orderid { get; set; }
    }
}
