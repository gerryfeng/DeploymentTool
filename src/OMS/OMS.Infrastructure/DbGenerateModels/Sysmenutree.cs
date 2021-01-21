using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Sysmenutree
    {
        public Sysmenutree()
        {
            Syspurviews = new HashSet<Syspurview>();
        }

        public int Id0 { get; set; }
        public int Nodeid { get; set; }
        public string Nodename { get; set; }
        public string Nodeshortname { get; set; }
        public int Parentid { get; set; }
        public string Pageurl { get; set; }
        public string Ownergroupcode { get; set; }
        public string Iscanmanage { get; set; }
        public string Ishidden { get; set; }
        public string Editgroupcode { get; set; }
        public int? Tableid { get; set; }
        public int? Orderid { get; set; }
        public string Defaultimgurl { get; set; }
        public string Expandimgurl { get; set; }
        public string Selectimgurl { get; set; }
        public int? Extauth { get; set; }
        public int? Independentpurviw { get; set; }
        public int? Left { get; set; }
        public int? Top { get; set; }
        public int? Right { get; set; }
        public int? Bottom { get; set; }
        public string Config { get; set; }
        public string Menuview { get; set; }
        public string Buttongroup { get; set; }
        public string Grouplabel { get; set; }
        public string Visible { get; set; }
        public string Subpageurl { get; set; }
        public string Param { get; set; }

        public virtual ICollection<Syspurview> Syspurviews { get; set; }
    }
}
