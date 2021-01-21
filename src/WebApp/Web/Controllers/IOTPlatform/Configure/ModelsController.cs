using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DTO;
using Web.Models.Configure.Entity;
using Web.Services.Configure;

namespace Web.Controllers.Configure
{

    /// <summary>
    /// 模型管理
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ModelsController : Controller
    {

        public IModelService modelService;

        public ModelsController(IModelService _modelService)
        {
            modelService = _modelService;
        }

     
       
        /// <summary>
        /// 获取模型列表
        /// </summary>
        /// <param name="dimonsion">维度</param>
        /// <param name="name">模型名称</param>
        /// <param name="type">类型</param>
        /// <param name="pageIndex">起始页</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        [HttpGet("Models/ModelList")]
        public async Task<Results<ModelDTO>> GetModelList(string dimonsion,string name,string type,int pageIndex,int pageSize)
        {
            return await modelService.GetModelList(dimonsion,type,name, pageIndex, pageSize);
        }

        /// <summary>
        /// 保存模型文件
        /// </summary>
        /// <param name="modelUpload"></param>
        /// <returns></returns>
        [HttpPost("Models/SaveUpload")]
        public async Task<Status> SaveUploadFiles([FromForm]ModelUpload modelUpload)
        {
            return await modelService.SaveModel(modelUpload);
        }

        /// <summary>
        /// 批量上传模型文件
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost("Models/BatchImport")]
        public async Task<Status> BatchImportUploadFiles([FromForm] string Type, [FromForm] string Dimonsion, List<IFormFile> files)
        {
            return await modelService.BatchSaveModel(Type,Dimonsion, files);
        }

        /// <summary>
        /// 删除模型文件
        /// </summary>
        [HttpGet("Models/DeleteByModel")]
        public async Task<Status> DeleteByModel(string ids)
        {
            return await modelService.DeleteByModel(ids);
        }



        /// <summary>
        /// 运维模型管理
        /// </summary>
        /// <param name="dimonsion"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("Models/ModelManageList")]
        public async Task<Results<ModelDTO>> ModelManageList(string dimonsion, string name, string type, int pageIndex, int pageSize)
        {
            return await modelService.GetModelManageList(dimonsion, type, name, pageIndex, pageSize);
        }


        /// <summary>
        /// mongo库迁移到sqlServer
        /// </summary>
        /// <returns></returns>
        [HttpGet("Models/DataMove")]
        public async Task<Status> DataMove()
        {
            return await modelService.DataMove();
        }

        /// <summary>
        /// 批量导出模型文件
        /// </summary>
        /// <param name="Ids">模型Id</param>
        /// <param name="dimonsion">维度</param>
        /// <returns></returns>
        [HttpGet("Models/Export")]
        public async Task<ActionResult> Export(string Ids,string dimonsion)
        {
            return File(await modelService.Export(Ids,dimonsion), "application/octet-stream", DateTime.Now + ".zip");
        }


        /// <summary>
        /// 批量导入模型文件
        /// </summary>
        /// <param name="file">画板zip</param>
        /// <returns></returns>
        [HttpPost("Models/Import")]
        public async Task<Status> Import(IFormFile file)
        {
            return await modelService.Import(file);
        }
    }


}