using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CycleId { get; set; }
        public int? AreaId { get; set; }
        public string FilterIds { get; set; }
        public string FilterNames { get; set; }
        public int? TolenceTime { get; set; }
        public string Travel { get; set; }
        public DateTime? StartTime { get; set; }
        public string StartMonth { get; set; }
        public string StartWeek { get; set; }
        public string StartWeekday { get; set; }
        public string UserIds { get; set; }
        public string UserNames { get; set; }
        public int? SeedId { get; set; }
        public string Station { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Creator { get; set; }
        public string CreatorDept { get; set; }
        public string Description { get; set; }
        public int? IsSend { get; set; }
        public int? UseFlag { get; set; }
        public int? IsExist { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? Time1 { get; set; }
        public DateTime? Time2 { get; set; }
        public int? NeedFeedBack { get; set; }
        public int? WeekEndTask { get; set; }
    }
}
