using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class NotificationStatus
    {
        public int Id { get; set; }
        public int? InfoId { get; set; }
        public int? UserId { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? CreateTime { get; set; }

        public virtual NotificationInfoHistory Info { get; set; }
    }
}
