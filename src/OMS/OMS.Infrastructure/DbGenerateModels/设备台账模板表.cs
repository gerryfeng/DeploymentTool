using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备台账模板表
    {
        public long Id { get; set; }
        public string 状态 { get; set; }
        public string Gis编号 { get; set; }
        public string Gis图层 { get; set; }
        public string 坐标位置 { get; set; }
        public string 设备名称 { get; set; }
        public DateTime? 上次养护时间 { get; set; }
        public DateTime? 计划养护开始时间 { get; set; }
        public DateTime? 计划养护结束时间 { get; set; }
        public string 所属站点 { get; set; }
        public string 养护周期 { get; set; }
        public string 养护人 { get; set; }
        public string 区域名称 { get; set; }
        public string 养护类型 { get; set; }
        public string 位置 { get; set; }
        public string 业务名称 { get; set; }
        public string 备注 { get; set; }
    }
}
