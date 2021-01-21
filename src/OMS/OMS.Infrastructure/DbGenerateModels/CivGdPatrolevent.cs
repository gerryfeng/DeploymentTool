using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivGdPatrolevent
    {
        public long Id { get; set; }
        public string Eventcode { get; set; }
        public string Eventsource { get; set; }
        public string Eventstate { get; set; }
        public string Eventtype { get; set; }
        public string Eventclass { get; set; }
        public string Districtname { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public string Audios { get; set; }
        public int? Reporterid { get; set; }
        public string Reportername { get; set; }
        public string Reportergroup { get; set; }
        public DateTime? Reporttime { get; set; }
        public string Position { get; set; }
        public string Reason { get; set; }
        public string Usercode { get; set; }
        public string Username { get; set; }
        public string Usertel { get; set; }
        public string LayerName { get; set; }
        public string FieldValue { get; set; }
        public string FieldName { get; set; }
        public string Taskid { get; set; }
        public int? Exist { get; set; }
    }
}
