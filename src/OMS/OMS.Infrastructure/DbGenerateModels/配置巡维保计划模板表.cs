using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 配置巡维保计划模板表
    {
        public int Id { get; set; }
        public string 业务名称 { get; set; }
        public string 业务类型 { get; set; }
        public string 执行周期 { get; set; }
        public string 台账名称 { get; set; }
        public string 反馈名称 { get; set; }
        public string 台账过滤条件 { get; set; }
        public string 是否送审 { get; set; }
        public string 执行角色 { get; set; }
        public string 预生成天数 { get; set; }
        public string 在线任务量 { get; set; }
        public string 启停 { get; set; }
        public int? 是否删除 { get; set; }
    }
}
