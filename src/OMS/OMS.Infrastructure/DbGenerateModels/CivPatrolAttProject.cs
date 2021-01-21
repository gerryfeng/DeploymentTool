using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolAttProject
    {
        public long Id { get; set; }
        public string 事件编号 { get; set; }
        public string 事件状态 { get; set; }
        public string 事件名称 { get; set; }
        public string 上报站点 { get; set; }
        public string 处理站点 { get; set; }
        public string 上报人名称 { get; set; }
        public string 上报人部门 { get; set; }
        public DateTime? 上报时间 { get; set; }
        public string 现场图片 { get; set; }
        public string 现场录音 { get; set; }
        public string 坐标位置 { get; set; }
        public DateTime? 更新时间 { get; set; }
        public string 更新状态 { get; set; }
        public string 外包矩形 { get; set; }
        public int? IsUpdate { get; set; }
        public string 事件备注 { get; set; }
        public string 工单编号 { get; set; }
        public int? 是否置顶 { get; set; }
        public int? 是否采集完成 { get; set; }
        public string 工程名称 { get; set; }
        public string 是否导出过点线表 { get; set; }
        public DateTime? 入库时间 { get; set; }
        public DateTime? 采集时间 { get; set; }
        public int? 是否删除 { get; set; }
        public string 采集人 { get; set; }
        public string 入库人 { get; set; }
        public string 完结人 { get; set; }
    }
}
