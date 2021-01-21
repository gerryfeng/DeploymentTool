using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OMS.ApplicationCore
{
    /// <summary>
    /// 文件路径返回Model
    /// </summary>
    public class FileModel
    {
        public FileModel()
        {
            fileUrls = new List<string>();
            child = new List<FileModel>();
        }

        /// <summary>
        /// 模块名
        /// </summary>
        public string moduleName { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public List<string> fileUrls { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        public List<FileModel> child { get; set; }
    }


    public class ApkUploadModel
    {
        /// <summary>
        /// 描述
        /// </summary>
        [Required, Description("描述")]
        public string description { get; set; }

        /// <summary>
        /// 是否强制刷新
        /// </summary>
        public bool isRefresh { get; set; }

        /// <summary>
        /// client类型
        /// </summary>
        [Required, Description("client类型")]
        public string client { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string apkPath { get; set; }

        public string updateTime { get; set; }
    }
}
