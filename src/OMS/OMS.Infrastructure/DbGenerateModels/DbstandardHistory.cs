using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class DbstandardHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Represent { get; set; }
        public string Content { get; set; }
        public string 方案名称 { get; set; }
    }
}
