using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Web.DTO;
using Web.DTO.Configure;
using Web.Services.Configure.Services;

namespace Web.Controllers.Configure
{
    /// <summary>
    /// web组态api
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SketchpadController : ControllerBase
    {

        /// <summary>
        ///  注册servers
        /// </summary>
        private readonly ISketchpadService sketchpadService;

        public SketchpadController(ISketchpadService service)
        {
            sketchpadService = service;
        }

        /// <summary>
        /// 获取画板列表接口
        /// </summary>
        /// <param name="pageIndex">起始页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="siteCode">站点编号</param>
        /// <param name="isTemplate">是否模板</param>
        /// <param name="name">画板名称</param>
        /// <param name="dimension">维度</param>
        /// <param name="queryInfo">模糊查询条件</param>
        /// <param name="typeID">类型ID</param>
        /// <param name="siteInfo">站点信息</param>
        /// <param name="version">版本</param>
        /// <returns></returns>
        [HttpGet("SketchPad/List")]
        public async Task<Results<QuerySketch>> GetSketchpad(int pageIndex,int pageSize,string siteCode,int isTemplate, string name,string dimension,string queryInfo,string siteInfo,int typeID,string version)
        {
            return await sketchpadService.GetSketchpadList(pageIndex,pageSize,siteCode, isTemplate,name, dimension,queryInfo, siteInfo, typeID,version);
        }


        /// <summary>
        /// 获取画板点表服务
        /// </summary>
        /// <returns></returns>
        [HttpGet("SketchPad/PointDetails")]
        public async Task<Results<SketchpadDetailListDTO>> GetPointDetails()
        {
            return await sketchpadService.GetPointDetails();
        }



        /// <summary>
        /// 保存画板
        /// </summary>
        /// <param name="sketchPad"></param>
        /// <returns></returns>
        [HttpPost("SketchPad/SaveSketchPad")]
        public async Task<Status> SaveSketchPad([FromForm] SketchPadSaveDTO sketchPad)
        {
            return await sketchpadService.SaveSketchPad(sketchPad);
        }


        /// <summary>
        /// 获取设备类型
        /// </summary>
        /// <returns></returns>
        [HttpGet("SketchPad/DeviceTypeName")]
        public async Task<Results<DeviceTypeDTO>> SketchpadByDeviceTypeName()
        {
            return await sketchpadService.SketchpadByDeviceTypeName();
        }



        /// <summary>
        /// 删除画板
        /// </summary>
        /// <param name="ID">画板ID</param>
        /// <returns></returns>
        [HttpGet("SketchPad/deleteByID")]
        public async Task<Status> DeleteByID(string ids)
        {
            return await sketchpadService.DeleteByID(ids);
        }


        /// <summary>
        /// 批量导出画板
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpGet("SketchPad/Export")]
        public async Task<ActionResult> Export(string Ids)
        {
            return File(await sketchpadService.Export(Ids), "application/octet-stream",DateTime.Now+".zip");
        }


        /// <summary>
        /// 批量导入画板文件
        /// </summary>
        /// <param name="importZip"></param>
        /// <returns></returns>
        [HttpPost("SketchPad/Import")]
        public async Task<Status> Import([FromForm] ImportZip importZip)
        {
            return await sketchpadService.Import(importZip);
        }

  

        /// <summary>
        /// 画板案例转换模板
        /// </summary>
        /// <param name="Id">画板ID</param>
        /// <returns></returns>
        [HttpGet("SketchPad/CaseTemplate")]
        public async Task<Status> CaseTemplate(string Id)
        {
            return await sketchpadService.CaseTemplate(Id);
        }


        /// <summary>
        /// 运维画板编辑
        /// </summary>
        /// <param name="Id">画板Id</param>
        /// <param name="Name">画板名称</param>
        /// <param name="ThreeName">关联三维模型</param>
        /// <param name="panoramicModel">全景模型</param>
        /// <returns></returns>
        [HttpGet("SketchPad/Edit")]
        public async Task<Status> Edit(string Id,string Name,string ThreeName,string TypeId,string panoramicModel)
        {
            return await sketchpadService.Edit(Id, Name, ThreeName,TypeId,panoramicModel);
        }

        /// <summary>
        /// 历史画板mongo库迁移到sqlServer
        /// </summary>
        /// <returns></returns>
        [HttpGet("SketchPad/DataMove")]
        public async Task<Status> DataMove()
        {
            return await sketchpadService.DataMove();
        }

    }
}
