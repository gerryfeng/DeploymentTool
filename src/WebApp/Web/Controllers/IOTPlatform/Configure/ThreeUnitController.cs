using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DTO;
using Web.DTO.Configure;
using Web.Models.ThreeConfigure;
using Web.Services.IOTPlatform.Configure;

namespace Web.Controllers.IOTPlatform.Configure
{

    /// <summary>
    /// 三维组态相关接口
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ThreeUnitController : Controller
    {
        private IThreeUnitService _threeUnitService;

        public ThreeUnitController(IThreeUnitService _threeUnitService)
        {
            this._threeUnitService = _threeUnitService;
        }



        /// <summary>
        /// 根据类型返回三维特征
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet("ThreeUnit/ModelType")]
        public async Task<Results<ModelFeature>> GetModelTypeList(string type)
        {
            return await _threeUnitService.GetFeatureByType(type);
        }

        /// <summary>
        /// 根据类型特征返回数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="feature"></param>
        /// <returns></returns>
        [HttpGet("ThreeUnit/modelFeatureData")]
        public async Task<Results<ModelFeatureData>> GetFeatureDataByTypeAndFeature(string type,string feature)
        {
            return await _threeUnitService.GetFeatureDataByTypeAndFeature(type, feature);
        }

        /// <summary>
        /// 获取默认三维模型
        /// </summary>
        /// <returns></returns>
        [HttpGet("ThreeUnit/GetModelByDefault")]
        public async Task<Results<ModelFeatureData>> GetModelByDefault()
        {
            return await _threeUnitService.GetModelByDefault();
        }

        #region 三维场景
        /// <summary>
        /// 新增三维场景
        /// </summary>
        /// <param name="sketchInfo"></param>
        /// <returns></returns>
        [HttpPost("ThreeUnit/AddSceneInfo")]
        public Status AddThreeSketch([FromForm] ThreeSketch sketchInfo)
        {
            return _threeUnitService.AddThreeSketch(sketchInfo);
        }

        /// <summary>
        /// 编辑三维场景
        /// </summary>
        /// <param name="sketchInfo"></param>
        /// <returns></returns>
        [HttpPost("ThreeUnit/EditThreeSketch")]
        public Status EditThreeSketch([FromForm] ThreeSketch sketchInfo)
        {
            return null;
        }
        /// <summary>
        /// 查询所有的三维场景
        /// </summary>
        /// <returns></returns>
        [HttpGet("ThreeUnit/QueryAllThreeSketch")]
        public Results<ThreeSketch> QueryThreeSketch()
        {
            return _threeUnitService.QueryAllThreeSketch(); 
        }

        /// <summary>
        /// 根据id获取三维场景信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ThreeUnit/QueryThreeSketchById")]
        public Results<ThreeSketch> QueryThreeSketchById(int id)
        {
            return _threeUnitService.QueryThreeSketchById(id);
        }

        /// <summary>
        /// 根据id删除三维场景信息
        /// </summary>
        /// <param name="ids">待删除的id列表 eg:1,2,3</param>
        /// <returns></returns>
        [HttpGet("ThreeUnit/DeleteThreeSketch")]
        public Status DeleteThreeSketch(string ids)
        {
            return _threeUnitService.DeleteThreeSketch(ids);
        }

        #endregion

        #region 模型分组
        /// <summary>
        /// 添加三维模型分组信息
        /// </summary>
        /// <param name="modelGroup"></param>
        /// <returns></returns>
        [HttpPost("ThreeUnit/AddThreeModelGroup")]
        public Status AddThreeModelGroup([FromForm] ThreeModelGroup modelGroup)
        {
            return _threeUnitService.AddThreeModelGroup(modelGroup);
        }

        /// <summary>
        /// 查询所有的模型类型信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("ThreeUnit/QueryAllThreeModelGroup")]
        public Results<ThreeModelGroup> QueryAllThreeModelGroup()
        {
            return _threeUnitService.QueryAllThreeModelGroup();
        }

        /// <summary>
        /// 根据id获取模型类型信息
        /// </summary>
        /// <param name="id">eg:1</param>
        /// <returns></returns>
        [HttpGet("ThreeUnit/QueryThreeModelGroupById")]
        public Results<ThreeModelGroup> QueryThreeModelGroupById(int id)
        {
            return _threeUnitService.QueryThreeModelGroupById(id);
        }

        /// <summary>
        /// 根据id删除模型类型信息
        /// </summary>
        /// <param name="ids">待删除的id列表 eg:1,2,3</param>
        /// <returns></returns>
        [HttpGet("ThreeUnit/DeleteModelGroup")]
        public Status DeleteModelGroup(string ids)
        {
            return _threeUnitService.DeleteThreeSketch(ids);
        }

        #endregion

        #region 模型
        /// <summary>
        /// 新增模型
        /// </summary>
        /// <param name="threeModel">待删除的id列表 eg:1,2,3</param>
        /// <returns></returns>
        [HttpPost("ThreeUnit/AddThreeModel")]
        public Status AddThreeModel([FromForm]ThreeModel threeModel)
        {
            return _threeUnitService.AddThreeModel(threeModel);
        }

        /// <summary>
        /// 根据id删除模型信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet("ThreeUnit/DeleteThreeModel")]
        public Status DeleteThreeModel(string ids)
        {
            return _threeUnitService.DeleteThreeModel(ids);
        }

        /// <summary>
        /// 查询所有模型信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("ThreeUnit/QueryAllThreeModel")]
        public Results<ModelResult> QueryAllThreeModel()
        {
            return _threeUnitService.QueryAllThreeModel();
        }

        /// <summary>
        /// 根据分组类型id查询所属模型
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        [HttpGet("ThreeUnit/QueryThreeModelByGroup")]
        public Results<ModelResult> QueryThreeModelByGroup(long groupID)
        {
            return _threeUnitService.QueryThreeModelByGroup(groupID);
        }

        /// <summary>
        /// 根据id导出模型
        /// </summary>
        /// <param name="id"> 模型id eg:id</param>
        /// <returns></returns>
        [HttpGet("ThreeUnit/ExportModelById")]
        public Results<Stream> ExportModel(long id)
        {
            return _threeUnitService.ExportModel(id);
        }

        #endregion
    }
}