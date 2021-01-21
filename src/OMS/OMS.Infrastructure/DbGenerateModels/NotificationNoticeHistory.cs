using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class NotificationNoticeHistory
    {
        public int Id { get; set; }
        public int? NoticeId { get; set; }
        public string InfoType { get; set; }
        public string NoticeType { get; set; }
        public string NoticeTitle { get; set; }
        public string NoticeContent { get; set; }
        public string ToUsers { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreateMen { get; set; }
        public int? 是否删除 { get; set; }
        public DateTime? 录入时间 { get; set; }
    }
}
