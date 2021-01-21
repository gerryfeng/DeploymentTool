using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Upfileslist
    {
        public int Id0 { get; set; }
        public string Caseno { get; set; }
        public int Materialid { get; set; }
        public string Materialname { get; set; }
        public int? Pagecontent { get; set; }
        public int Fileno { get; set; }
        public string Filename { get; set; }
        public byte[] Filecontent { get; set; }
        public string Remark { get; set; }
        public string Reserve1 { get; set; }
        public string Reserve2 { get; set; }
    }
}
