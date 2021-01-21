using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.ApplicationCore
{
    [Table("FLOW_USER_ROLE")]
    public class Flow_User_Role:BaseEntity
    {
        [ForeignKey("Flow_Users")]
        public int 用户ID { get; set; }

        [ForeignKey("Flow_Groups")]
        public int 机构ID { get; set; }

        public  Flow_Users User { get; set; }

        public  Flow_Groups Group { get; set; }
    }
}
