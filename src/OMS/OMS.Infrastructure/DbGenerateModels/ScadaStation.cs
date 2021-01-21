using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaStation
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public int? Pid { get; set; }
        public int? DivisionId { get; set; }
        public int? StationTypeId { get; set; }
        public string StationNo { get; set; }
        public double? MinScale { get; set; }
        public double? MaxScale { get; set; }
        public string Address { get; set; }
        public string 坐标位置 { get; set; }
        public string ReadMode { get; set; }
        public int? 是否删除 { get; set; }
        public string AreaName { get; set; }
        public string FopcserverName { get; set; }
        public string Fplcip { get; set; }
        public string ShortName { get; set; }
        public string ControlType { get; set; }
        public string FopcdeviceName { get; set; }
        public DateTime? 录入时间 { get; set; }
        public string 采集频度 { get; set; }
        public string Code { get; set; }
        public int? LedgerId { get; set; }
        public string LedgerTable { get; set; }
        public int? AddrSchemeId { get; set; }
    }
}
