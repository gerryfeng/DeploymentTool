using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class FlowGroup
    {
        public FlowGroup()
        {
            Syspurviews = new HashSet<Syspurview>();
        }

        public int 机构id { get; set; }
        public string 名称 { get; set; }
        public int 类型 { get; set; }
        public string 编码 { get; set; }
        public string 描述 { get; set; }
        public int 级别 { get; set; }
        public string 备注 { get; set; }
        public string Password { get; set; }
        public int Indexorder { get; set; }
        public string 行政区划 { get; set; }
        public int? 主管人 { get; set; }
        public string 城市 { get; set; }
        public string Ecode { get; set; }
        public string Visible { get; set; }
        public string 功能访问规则 { get; set; }
        public string 数据访问规则 { get; set; }

        public virtual ICollection<Syspurview> Syspurviews { get; set; }
    }
}
