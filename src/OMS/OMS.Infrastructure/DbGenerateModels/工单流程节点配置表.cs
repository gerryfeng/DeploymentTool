using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单流程节点配置表
    {
        public long Id { get; set; }
        public string 流程名称 { get; set; }
        public string 节点名称 { get; set; }
        public string 移交方式 { get; set; }
        public string 操作类型 { get; set; }
        public string 表名 { get; set; }
        public string 字段集 { get; set; }
        public string 视图模块 { get; set; }
        public string 手持视图模块 { get; set; }
        public string 视图参数 { get; set; }
        public int? 可否补正 { get; set; }
        public int? 可否回退 { get; set; }
        public string 回退至节点 { get; set; }
        public string 反馈名称 { get; set; }
        public int? 反馈显示到事件 { get; set; }
        public int? 显示事件信息 { get; set; }
        public string 节点别名 { get; set; }
        public string 查看字段集 { get; set; }
        public int? 可否平级移交 { get; set; }
    }
}
