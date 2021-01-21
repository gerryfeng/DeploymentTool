using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.DTO;
using Web.Models.Configure.Entity;
using Web.Services.IOTPlatform.Configure;

namespace Web.Controllers.IOTPlatform.Configure
{

    /// <summary>
    /// 画板类型管理
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SketchPadTypeController : ControllerBase
    {
        public ISketchPadTypeService SketchPadTypeService;

        public SketchPadTypeController(ISketchPadTypeService _SketchPadTypeService)
        {
            SketchPadTypeService = _SketchPadTypeService;
        }


        /// <summary>
        /// 获取运维模型类型管理列表
        /// </summary>
        /// <param name="pageSize">条数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="name">类型名称</param>
        /// <returns></returns>
        [HttpGet("SketchPadType/List")]
        public async Task<Results<SketchPadType>> GetTypeList(int pageSize, int pageIndex, string name)
        {
            return await SketchPadTypeService.GetTypeList(pageSize, pageIndex, name);
        }


        /// <summary>
        /// 保存画板类型
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost("SketchPadType/Save")]
        public async Task<Status> Save(SketchPadType sketchPadType)
        {
            return await SketchPadTypeService.SaveSketchPadType(sketchPadType);
        }

    }
}