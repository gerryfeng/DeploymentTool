using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolNote
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? NoteTime { get; set; }
        public string Detail { get; set; }
        public string Remark { get; set; }
    }
}
