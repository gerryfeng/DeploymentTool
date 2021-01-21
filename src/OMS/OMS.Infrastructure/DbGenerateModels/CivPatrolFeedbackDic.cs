using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class CivPatrolFeedbackDic
    {
        public int Id { get; set; }
        public int? FilterId { get; set; }
        public string Name { get; set; }
        public string FeedbackType { get; set; }
        public string DefaultValues { get; set; }
        public int? IsEnable { get; set; }
        public int? IsTrigger { get; set; }
        public string Condition { get; set; }
        public int? IsRequired { get; set; }
        public int? OrderId { get; set; }
    }
}
