using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{
    public class SketchPadSaveDTO
    {

        /// <summary>
        /// 画板名称
        /// </summary>
        [Required(ErrorMessage = "画板名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 维度
        /// </summary>
       [Required(ErrorMessage = "类型不能为空")]
       public string Dimonsion { get; set; }

        /// <summary>
        /// 是否模板
        /// </summary>
        public int isTemplate { get; set; } = 0;

        /// <summary>
        /// Svg字符串
        /// </summary>
        [Required(ErrorMessage = "画板svg不能为空")]
        public string data { get; set; }

        /// <summary>
        /// 关联三维模型名称
        /// </summary>
        public string ThreeDimonsionName { get; set; }

        /// <summary>
        /// 点表版本
        /// </summary>
        [Required(ErrorMessage = "点表版本不能为空")]
        public string pointVersion { get; set; }

        /// <summary>
        /// json字符串
        /// </summary>
        [Required(ErrorMessage = "画板Json不能为空")]
        public string jsonStr { get; set; }

        public int num { get; set; }//画板站点个数

        /// <summary>
        /// 站点编码
        /// </summary>
        [Required(ErrorMessage = "siteCode不能为空")]
        public string siteCode { get; set; }

        /// <summary>
        /// 站点信息
        /// </summary>
        public string siteInfo { get; set; }

        /// <summary>
        /// 类型ID
        /// </summary>
        public int ? TypeID { get; set; }

        /// <summary>
        /// 项目简称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 是否样板
        /// </summary>
        public int Templet { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public string ? Version { get; set; }

    }
}
