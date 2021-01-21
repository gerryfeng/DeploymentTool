using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Patrolmanlog
    {
        public int Id { get; set; }
        public int? 用户编号 { get; set; }
        public DateTime? 操作时间 { get; set; }
        public string 操作类型 { get; set; }
    }
}
