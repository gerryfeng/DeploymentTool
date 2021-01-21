using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class 组态画板
    {
        public int Id { get; set; }
        public string 画板名称 { get; set; }
        public string 维度 { get; set; }
        public string 摄相机xyz { get; set; }
        public string 配置文件url { get; set; }
        public string 点表版本 { get; set; }
        public bool? 是否模板 { get; set; }
        public string 缩略图url { get; set; }
        public string 关联三维模型名称 { get; set; }
        public int? 是否删除 { get; set; }
        public int? 站点个数 { get; set; }
        public string SiteCode { get; set; }
        public string 站点信息 { get; set; }
        public string 全景模型 { get; set; }
        public byte[] 画板json { get; set; }
        public int? 类型id { get; set; }
        public byte[] 画板图片 { get; set; }
        public int? 热度 { get; set; }
        public string 项目简称 { get; set; }
        public int? 是否样板 { get; set; }
    }
}
