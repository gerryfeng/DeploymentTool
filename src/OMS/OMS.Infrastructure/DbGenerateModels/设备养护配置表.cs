using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备养护配置表
    {
        public long Id { get; set; }
        public string 业务名称 { get; set; }
        public string 任务编码前缀 { get; set; }
        public string 计划养护类型 { get; set; }
        public string Gis图层 { get; set; }
        public string Gis条件 { get; set; }
        public string 设备台账表 { get; set; }
        public string 站点 { get; set; }
        public string 台账字段集 { get; set; }
        public string 台账显示字段 { get; set; }
        public string 设备任务表 { get; set; }
        public string 任务字段集 { get; set; }
        public string 任务显示字段集 { get; set; }
        public string 任务审核列表字段 { get; set; }
        public string 手持任务列表字段 { get; set; }
        public string 手持任务列表字段描述 { get; set; }
        public int? 能否gis分区 { get; set; }
        public int? 是否自动派发 { get; set; }
        public int? 能否延期 { get; set; }
        public int? 容忍延期天数 { get; set; }
        public int? 能否退单 { get; set; }
        public int? 能否编辑台账 { get; set; }
        public int? 手持能否编辑台账 { get; set; }
        public int? 能否添加台账 { get; set; }
        public int? 能否同步数据 { get; set; }
        public int? 能否添加材料 { get; set; }
        public int? 能否添加耗材 { get; set; }
        public int? 添加到停气列表 { get; set; }
        public int? 任务生成时长 { get; set; }
        public string 养护人员角色 { get; set; }
        public string 基准时间字段 { get; set; }
        public string 关联事件 { get; set; }
    }
}
