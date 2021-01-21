using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 组态模型表
    {
        public int Id { get; set; }
        public string 模型名称 { get; set; }
        public string 类型名称 { get; set; }
        public string 维度 { get; set; }
        public string 模型存储路径 { get; set; }
        public string 模型长宽高 { get; set; }
        public string 图标路径 { get; set; }
        public DateTime? 创建日期 { get; set; }
        public string 创建人 { get; set; }
        public int? 是否删除 { get; set; }
        public int? 模型维度关联 { get; set; }
        public string 材质文件路径 { get; set; }
        public string 特征 { get; set; }
        public int? 是否编辑 { get; set; }
        public byte[] 模型文件 { get; set; }
    }
}
