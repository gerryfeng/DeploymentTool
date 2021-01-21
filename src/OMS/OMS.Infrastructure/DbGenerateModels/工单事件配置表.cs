using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 工单事件配置表
    {
        public long Id { get; set; }
        public string 业务编码 { get; set; }
        public string 业务类型 { get; set; }
        public string 事件名称 { get; set; }
        public string 事件主表 { get; set; }
        public string 字段集 { get; set; }
        public string 摘要字段 { get; set; }
        public string 事件权限 { get; set; }
        public int? 是否发起 { get; set; }
        public int? 是否上报 { get; set; }
        public int? 是否编辑 { get; set; }
        public string 编辑字段集 { get; set; }
        public string 显示字段集 { get; set; }
        public int? 显示顺序 { get; set; }
        public int? 前端权限 { get; set; }
        public int? 手持权限 { get; set; }
        public string 置顶条件 { get; set; }
        public string 前端处理视图 { get; set; }
        public string 关联事件 { get; set; }
        public string 关联字段集 { get; set; }
        public string 事件接口配置 { get; set; }
        public string 转单字段集 { get; set; }
        public string 视图模块 { get; set; }
        public string 图片表达 { get; set; }
    }
}
