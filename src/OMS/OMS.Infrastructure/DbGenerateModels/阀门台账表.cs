using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 阀门台账表
    {
        public long Id { get; set; }
        public string Gis编号 { get; set; }
        public string Gis图层 { get; set; }
        public string 设备名称 { get; set; }
        public DateTime? 上次养护时间 { get; set; }
        public DateTime? 计划养护开始时间 { get; set; }
        public DateTime? 计划养护结束时间 { get; set; }
        public string 坐标位置 { get; set; }
        public string 所属站点 { get; set; }
        public string 位置 { get; set; }
        public string 阀门性质 { get; set; }
        public string 联系人 { get; set; }
        public string 联系方式 { get; set; }
        public string 规格型号 { get; set; }
        public string 生产厂家 { get; set; }
        public string 供气范围 { get; set; }
        public string 启用时间 { get; set; }
        public string 运行状况 { get; set; }
        public string 投运时间 { get; set; }
        public DateTime? 出厂日期 { get; set; }
        public string 出厂编号 { get; set; }
        public string 设备级别 { get; set; }
        public string 状态 { get; set; }
        public string 是否停用或故障 { get; set; }
        public string 备注 { get; set; }
        public string 养护周期 { get; set; }
        public string 养护人id { get; set; }
        public string 养护人 { get; set; }
        public string 业务名称 { get; set; }
        public string 区域名称 { get; set; }
        public string 养护类型 { get; set; }
        public string 材质 { get; set; }
    }
}
