using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowGroupsAdmin
    {
        public int Id0 { get; set; }
        public string Groupcode { get; set; }
        public int? Adminuserid { get; set; }
        public int? Admintype { get; set; }
        public int? Adminlevel { get; set; }
        public string Admintarget { get; set; }
        public DateTime? Createtime { get; set; }
        public string Remark { get; set; }
    }
}
