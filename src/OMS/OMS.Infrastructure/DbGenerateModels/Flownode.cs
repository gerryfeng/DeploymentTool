using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Flownode
    {
        public int 活动id { get; set; }
        public int? 流程id { get; set; }
        public int? 节点id { get; set; }
        public string 节点名称 { get; set; }
        public int 节点类型 { get; set; }
        public int 联合标志 { get; set; }
        public decimal? 办理时限 { get; set; }
        public int 本节点协办标志 { get; set; }
        public string 备注 { get; set; }
        public int 是否检查前面在办 { get; set; }
        public int 子流程id { get; set; }
        public string 子流程属性 { get; set; }
        public int 角色过滤深度 { get; set; }
        public int 类型 { get; set; }
        public int 参照活动 { get; set; }
        public int 序号 { get; set; }
        public string 最短时限 { get; set; }
        public string 限时提醒 { get; set; }
        public int 会办角色id { get; set; }
        public int? 补正功能 { get; set; }
        public int? 汇总节点 { get; set; }
        public int? 计算时限 { get; set; }
        public string Canend { get; set; }
        public string Keynode { get; set; }
        public string Prenodes { get; set; }
        public string Readonly { get; set; }
        public string Sendmsm { get; set; }
        public string Sendsms { get; set; }
    }
}
