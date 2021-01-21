using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaStationDivision
    {
        public int Id { get; set; }
        public int? Pid { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public int? 是否删除 { get; set; }
        public DateTime? 录入时间 { get; set; }
    }
}
