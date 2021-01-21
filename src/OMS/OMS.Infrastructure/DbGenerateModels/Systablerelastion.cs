using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Systablerelastion
    {
        public int Id0 { get; set; }
        public string Tablename { get; set; }
        public string Indexfield { get; set; }
        public string Parenttblname { get; set; }
        public string Prttblindexname { get; set; }
        public string Prttblfilter { get; set; }
        public string Prttblfltvalue { get; set; }
        public string Reserve1 { get; set; }
        public string Reserve2 { get; set; }
    }
}
