using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class NotificationInfoReal
    {
        public int Id { get; set; }
        public string InfoType { get; set; }
        public string InfoContent { get; set; }
        public string Tousers { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? InfoLevel { get; set; }
        public string InfoDistribution { get; set; }
        public string MessTypeId { get; set; }
    }
}
