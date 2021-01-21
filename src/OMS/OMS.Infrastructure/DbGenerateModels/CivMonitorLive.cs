using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivMonitorLive
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string StreamId { get; set; }
        public DateTime? OperTime { get; set; }
        public string PreviewImage { get; set; }
        public int? LiveState { get; set; }
    }
}
