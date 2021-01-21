using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Jianloudetail
    {
        public int Id { get; set; }
        public int? EventId { get; set; }
        public string 漏点类型 { get; set; }
        public string 漏点大小 { get; set; }
        public string 初判级别 { get; set; }
        public string 管线编号 { get; set; }
        public string 分公司 { get; set; }
        public string 区块 { get; set; }
        public string 管线位置 { get; set; }
        public string 管径 { get; set; }
        public string 材质 { get; set; }
        public DateTime? 日期 { get; set; }
        public string 检漏情况 { get; set; }
        public string 漏点位置 { get; set; }
        public string 坐标 { get; set; }
        public string 漏点地面 { get; set; }
        public string 破损部位 { get; set; }
        public string 管道埋设 { get; set; }
        public int? 漏点管径 { get; set; }
        public DateTime? 登记时间 { get; set; }
    }
}
