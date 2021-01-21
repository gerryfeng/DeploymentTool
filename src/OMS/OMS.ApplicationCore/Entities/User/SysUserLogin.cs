using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.ApplicationCore
{
    /// <summary>
    /// 用户登录日志
    /// </summary>
    [Table("用户登录记录表")]
    public class SysUserLogin:BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("用户登录名")]
        public string LoginName { get; set; }

        [Column("用户名")]
        public string ShowName { get; set; }

        [Column("系统类型")]
        public string SystemType { get; set; }

        [Column("终端")]
        public string Terminal { get; set; }
        public string IP { get; set; }

        [Column("登录时间")]
        public DateTime LoginTime { get; set; }
    }
}
