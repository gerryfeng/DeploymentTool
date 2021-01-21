
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.DTO;
using Web.Models.Configure.Entity;
using Web.Services.Configure.Services;

namespace Web.Controllers.Configure
{
    /// <summary>
    /// 运维模型类型管理
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ModelTypeController : ControllerBase
    {

        public IModelTypeService modelService;

        public ModelTypeController(IModelTypeService _modelTypeService)
        {
            modelService = _modelTypeService;
        }


        /// <summary>
        /// 获取运维模型类型管理列表
        /// </summary>
        /// <param name="pageSize">条数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="name">类型名称</param>
        /// <returns></returns>
        [HttpGet("ModelType/TypeList")]
        public async Task<Results<ModelTypeDTO>> GetTypeList(int pageSize, int pageIndex, string name)
        {
            return await modelService.GetTypeList(pageSize, pageIndex,name); 
        }


        /// <summary>
        ///  获取模型类型
        /// </summary>
        /// <returns></returns>

        [HttpGet("ModelType/ModelList")]
        public async Task<Results<ModelType>> GetModelType(string name)
        {
            ModelType model = new ModelType();
            if (!string.IsNullOrEmpty(name)) model.Name = name;
            return await modelService.GetList(model);
        }


        /// <summary>
        /// 保存模型类型
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("ModelType/Save")]
        public IActionResult Save(string name,string creator)
        {
            return Ok(modelService.SaveModelType(name, creator));
        }
    }
}