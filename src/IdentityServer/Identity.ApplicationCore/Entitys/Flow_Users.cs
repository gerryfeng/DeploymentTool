using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.ApplicationCore
{
    [Table("FLOW_USERS")]
    public class Flow_Users
    {
        [Key]
        [Column("用户ID")]
        public int ID { get; set; }

        [Column("名称")]
        [Display(Name = "名称")]
        public string Name { get; set; }

        [Column("工号")]
        [Display(Name = "工号")]
        public string WorkNo { get; set; }

        [Column("备注")]
        [Display(Name = "备注")]
        public string Remark { get; set; }

        [Column("PASSWORD")]
        [Display(Name = "密码")]
        public string PASSWORD { get; set; }

        [Column("INDEXORDER")]
        [Display(Name = "INDEXORDER")]
        public int INDEXORDER { get; set; }

        [Column("PHONE")]
        [Display(Name = "手机号")]
        public string PHONE { get; set; }

        [Column("token")]
        [Display(Name = "TOKEN")]
        public string TOKEN { get; set; }

        public string ddid { get; set; }

        public string wxid { get; set; }
    }
}
