﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Configure
{

    [Table("组态_画板")]
    public class Sketchpad
    {

        [Key]
        [Column("ID")]
        public int ID { get; set; }
               
        [Required(ErrorMessage ="画板名称不能为空")]
        [Column("画板名称")]
        public string Name { get; set; }

        [Column("维度")]
        [Required]
        public string Dimonsion { get; set; }

        [Column("摄相机XYZ")]
        public string ? Camera { get; set; }

        [Column("配置文件Url")]
        public string DeployURL { get; set; }

        [Column("点表版本")]
        public string PointVersion { get; set; }

        [Column("是否模板")]
        public bool ? IsTemplate { get; set; }

        [Column("站点个数")]
        public int Num { get; set; }

        [Column("画板图片")]
        public Byte[] ? images { get; set; }

        [Column("缩略图URL")]
        public string ThumbnailURL { get; set; }

        [Column("关联三维模型名称")]
        public string ThreeDimonsionName { get; set; }


        [Column("是否删除")]
        public int IsDelete { get; set; }

        [Column("siteCode")]
        public string SiteCode { get; set; }

        [Column("站点信息")]
        public string SiteInfo { get; set; }

        [Column("画板Json")]
        public Byte[]? Json { get; set; }

        [Column("类型ID")]
        public int ? TypeID { get; set; }

        [Column("热度")]
        public int? Heat { get; set; }


        [Column("项目简称")]
        public string ? projectName { get; set; }

        [Column("全景模型")]
        public string? panoramicModel { get; set; }


        [Column("是否样板")]
        public int? Templet { get; set; } = 0;

        [Column("版本")]
        public string Version { get; set; }


    }
}
