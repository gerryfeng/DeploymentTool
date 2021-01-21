using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.ThreeConfigure
{
    [Table("三维组态模型信息表")]
    public class ThreeModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "bigint")]
        public long ID { get; set; }

        [Column("名称", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("别名", TypeName = "varchar(100)")]
        public string DisplayName { get; set; }

        [Column("编号", TypeName = "varchar(64)")]
        public string Code { get; set; }

        [Column("GroupID", TypeName = "bigint")]
        public long GroupID { get; set; }

        [Column("属性信息", TypeName = "varchar(max)")]
        public string Attribute { get; set; }

        [Column("AinimationID", TypeName = "bigint")]
        public long AinimationID { get; set; }

        [Column("创建人", TypeName = "varchar(64)")]
        public string CreateUser { get; set; }

        [Column("创建时间", TypeName = "datetime(64)")]
        public DateTime CreateTime { get; set; }

        [NotMapped]
        public IFormFile ModelFileData { get; set; }
    }


    public class ModelResult
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public string Code { get; set; }

        public long GroupID { get; set; }

        public string Attribute { get; set; }

        public long AinimationID { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateTime { get; set; }

        public string GroupName { get; set; }

        public string GroupCode { get; set; }

        public string AttributeIDs { get; set; }
    }


}
