using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Patrolshortmessage
    {
        public int MsgId { get; set; }
        public DateTime? MsgTime { get; set; }
        public int? Patrolerid { get; set; }
        public string MsgDetail { get; set; }
        public int Isget { get; set; }
        public int? Senderid { get; set; }
    }
}
