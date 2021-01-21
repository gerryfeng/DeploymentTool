using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Services.Configure;

namespace Web.Controllers.Configure
{

    /// <summary>
    ///  mongoDB 文件接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        private IFileService fileService;
        public IModelService modelService;

        public FileController(IFileService _fileService, IModelService _modelService)
        {
            fileService = _fileService;
            modelService = _modelService;
        }

      
        /// <summary>
        /// 模型文件预览
        /// </summary>
        /// <param name="dimonsion">维度</param>
        /// <param name="type">类型</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        [HttpGet("ModelManage/ModelFilePreview/{fileName}")]
        [ResponseCache(Duration = 3600)]//缓存1小时
        public async Task<Stream> GetModelPreviewFile(string fileName)
        {
            fileName = HttpUtility.UrlDecode(fileName);
            Response.ContentType = fileName.EndsWith("svg") ? "image/svg+xml" : "application/octet-stream";
            return new MemoryStream(await fileService.GetModelAsBytes("","", HttpUtility.UrlDecode(fileName)));
        }

        /// <summary>
        /// 模型下载
        /// </summary>
        /// <param name="dimonsion">维度</param>
        /// <param name="type">类型</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        [HttpGet("Model/DownLoad/{dimonsion}/{type}/{fileName}")]
        [ResponseCache(Duration = 600)]//缓存10分钟
        public async Task<IActionResult> DownLoadFile(string dimonsion, string type, string fileName)
        {
            Response.Headers.Add("Content-Disposition", "attachment; filename=" + fileName);
            return File(await fileService.GetModelAsBytes(dimonsion, type, fileName),"application/octet-stream", fileName);
        }


        /// <summary>
        /// 画板图片
        /// </summary>
        /// <param name="dimonsion"></param>
        /// <param name="siteCode"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet("Sketch/Preview/{dimonsion}/{siteCode}/{fileName}")]
        [ResponseCache(Duration = 60)]//缓存1分钟
        public async Task<Stream> SketchBlobFile(string dimonsion, string siteCode, string fileName)
        {
            return new MemoryStream(await fileService.GetSketchAsBytes(dimonsion, siteCode, fileName));
        }

        /// <summary>
        /// 获取画板Json
        /// </summary>
        /// <param name="dimonsion">维度</param>
        /// <param name="siteCode">站点编号</param>
        /// <param name="fileName">画板名称</param>
        /// <returns></returns>
        [HttpGet("Sketch/Content/{dimonsion}/{siteCode}/{fileName}")]
        public async Task<ActionResult> SketchBlobContent(string dimonsion, string siteCode, string fileName)
        {
            return Ok(await fileService.GetSketchAsContent(dimonsion, siteCode, fileName));
        }

    }
}