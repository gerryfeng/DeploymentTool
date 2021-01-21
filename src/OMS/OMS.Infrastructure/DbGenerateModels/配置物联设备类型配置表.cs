using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 配置物联设备类型配置表
    {
        public int Id { get; set; }
        public string 设备类型 { get; set; }
        public string 父类型名称 { get; set; }
        public string 分组名称 { get; set; }
        public string 台账表名 { get; set; }
        public string 实时数据表名 { get; set; }
        public string 历史数据表名 { get; set; }
        public string 统计数据表名 { get; set; }
        public string 地址方案名 { get; set; }
        public decimal? 采集频率 { get; set; }
        public decimal? 存储频率 { get; set; }
    }
}
