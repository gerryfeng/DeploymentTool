using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单表字段配置表
    {
        public long Id { get; set; }
        public string 表名 { get; set; }
        public string 字段名 { get; set; }
        public string 别名 { get; set; }
        public string 界面分组 { get; set; }
        public string 类型 { get; set; }
        public string 形态 { get; set; }
        public string 单位 { get; set; }
        public string 配置信息 { get; set; }
        public string 预设值 { get; set; }
        public int? 横跨距 { get; set; }
        public int? 纵跨距 { get; set; }
        public int? 只读 { get; set; }
        public string 验证规则 { get; set; }
        public int? 可否补正 { get; set; }
        public int? 显示顺序 { get; set; }
        public int? 同步到事件 { get; set; }
        public string 触发异常值 { get; set; }
        public string 触发事件 { get; set; }
        public string 触发事件字段集 { get; set; }
    }
}
