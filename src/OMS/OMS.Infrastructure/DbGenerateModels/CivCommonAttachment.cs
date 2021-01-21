using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivCommonAttachment
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Filesize { get; set; }
        public DateTime? Createtime { get; set; }
        public int? Userid { get; set; }
        public string Remark { get; set; }
        public string Path { get; set; }
    }
}
