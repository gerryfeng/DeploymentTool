using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Configure.Entity
{
    [Table("组态_模型类型表")]
    [Serializable]
    public class ModelType
    {

        [Column("ID")]
        public int ID { get; set; }

        [Column("类型名称")]
        public string Name { get; set; }

        [Column("创建人")]
        public string Founder { get; set; }

        [Column("创建日期")]
        public DateTime? CreateTime { get; set; }


    }
}
