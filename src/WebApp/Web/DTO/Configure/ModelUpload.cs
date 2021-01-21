using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO
{

    /// <summary>
    /// 模型文件上传
    /// </summary>
    public class ModelUpload
    {
        /// <summary>
        /// 模型名称
        /// </summary>
        [Required]
        public string Name { set; get; }

        /// <summary>
        /// 模型类型
        /// </summary>
        [Required]
        public string Type { set; get; }

        /// <summary>
        /// 维度
        /// </summary>
        [Required]
        public string Dimension { set; get; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { set; get; }

        /// <summary>
        /// 关联模型
        /// </summary>
        public string RelModel { set; get; }

        /// <summary>
        /// 模型长宽高
        /// </summary>
        public string Size { set; get; }

        /// <summary>
        /// 模型属性
        /// </summary>
        public string Attr { set; get; }

        /// <summary>
        /// 模型文件
        /// </summary>
        public IFormFile ModelFile { set; get; }

        //是否编辑
        public int IsEdit { set; get; } = 0;

        /// <summary>
        /// 材质文件
        /// </summary>
        public IFormFile File { set; get; }


    }
}
