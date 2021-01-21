using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Flowctrltbl
    {
        public int 流程id { get; set; }
        public string 流程名称 { get; set; }
        public int 流程编码 { get; set; }
        public string 流程描述 { get; set; }
        public decimal? 流程时限 { get; set; }
        public string 备注 { get; set; }
        public int 流程状态 { get; set; }
        public string 创建人 { get; set; }
        public DateTime? 创建时间 { get; set; }
        public string 流程版本 { get; set; }
        public int? 年份 { get; set; }
        public int? Nextcaseno { get; set; }
        public string 编号前缀 { get; set; }
        public string 所属系统 { get; set; }
        public int 流程类型 { get; set; }
    }
}
