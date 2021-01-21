using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 设备养护反馈配置表
    {
        public long Id { get; set; }
        public string 业务名称 { get; set; }
        public string 反馈类型 { get; set; }
        public string 设备名称 { get; set; }
        public string 部件名称 { get; set; }
        public string 养护内容 { get; set; }
        public string 过滤条件字段 { get; set; }
        public string 过滤条件值 { get; set; }
        public string 设备反馈表 { get; set; }
        public string 包含字段集 { get; set; }
        public string 排除字段集 { get; set; }
        public string 周期 { get; set; }
        public string 触发异常值 { get; set; }
        public string 触发事件 { get; set; }
        public string 前端列表字段 { get; set; }
        public string 手持列表字段 { get; set; }
        public string 触发事件字段集 { get; set; }
        public string 反馈角色 { get; set; }
    }
}
