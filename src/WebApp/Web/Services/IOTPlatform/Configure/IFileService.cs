using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services.Configure
{
   public interface IFileService
    {


        /// <summary>
        /// 模型文件预览下载
        /// </summary>
        /// <param name="dimonsion">维度</param>
        /// <param name="type">类型</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public Task<byte[]> GetModelAsBytes(string dimonsion, string type, string fileName);



        /// <summary>
        /// 获取画板图片
        /// </summary>
        /// <param name="dimonsion">维度</param>
        /// <param name="siteCode">站点编号</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public Task<byte[]> GetSketchAsBytes(string dimonsion, string siteCode, string fileName);



        /// <summary>
        /// 获取画板内容
        /// </summary>
        /// <param name="dimonsion"></param>
        /// <param name="siteCode"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<string> GetSketchAsContent(string dimonsion, string siteCode, string fileName);


    }
}
