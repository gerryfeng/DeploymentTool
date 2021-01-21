using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolTask
    {
        public int Id { get; set; }
        public int? PlanId { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CycleId { get; set; }
        public string CycleName { get; set; }
        public int? AreaId { get; set; }
        public string FilterId { get; set; }
        public string FilterName { get; set; }
        public int? TolenceTime { get; set; }
        public string Travel { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string CheckState { get; set; }
        public int? CheckId { get; set; }
        public string UserIds { get; set; }
        public string UserNames { get; set; }
        public int? IsSend { get; set; }
        public int? IsFinish { get; set; }
        public DateTime? FinishTime { get; set; }
        public int? ArriveSum { get; set; }
        public int? FeedbackSum { get; set; }
        public int? TotalSum { get; set; }
        public double? PipeLenth { get; set; }
        public double? TotalLenth { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Creator { get; set; }
        public string Station { get; set; }
        public string Description { get; set; }
        public int? IsExist { get; set; }
        public int? TotalFbsum { get; set; }
        public string TaskState { get; set; }
    }
}
