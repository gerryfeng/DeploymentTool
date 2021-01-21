using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class ScadaAlertInfo
    {
        public int Id { get; set; }
        public string AlertName { get; set; }
        public string AlertType { get; set; }
        public int? DataKind { get; set; }
        public int? UseFlag { get; set; }
        public string Sensors { get; set; }
        public string Stations { get; set; }
        public string Divisions { get; set; }
        public string Person { get; set; }
        public string Notify { get; set; }
        public int 是否删除 { get; set; }
    }
}
