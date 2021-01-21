using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Dma建设过程表
    {
        public int Id { get; set; }
        public string 分区编码 { get; set; }
        public string 建设环节 { get; set; }
        public string 建设模块 { get; set; }
        public string 建设内容 { get; set; }
        public string 建设详情 { get; set; }
        public string 责任人 { get; set; }
        public string 备注 { get; set; }
        public DateTime? 录入时间 { get; set; }
        public int? 是否删除 { get; set; }
    }
}
