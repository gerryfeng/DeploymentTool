using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO;
using Web.DTO.Configure;
using Web.Models.Configure;
using Web.Models.Configure.Entity;

namespace Web.Services.Configure.Services
{
    public interface ISketchpadService 
    {

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
        /// <param name="siteInfo">站点信息</param>
        /// <param name="typeID">类型ID</param>
        /// <param name="version">版本</param>
        /// <returns></returns>
        Task<Results<QuerySketch>> GetSketchpadList(int pageIndex, int pageSize, string siteCode, int isTemplate, string name, string dimension, string queryInfo, string siteInfo,int typeID,string version);


        /// <summary>
        /// 获取点表明细
        /// </summary>
        /// <returns></returns>
        Task<Results<SketchpadDetailListDTO>> GetPointDetails();


        /// <summary>
        /// 保存画板
        /// </summary>
        /// <returns></returns>
        Task<Status> SaveSketchPad(SketchPadSaveDTO sketchPadDTO);

        /// <summary>
        /// 获取设备类型
        /// </summary>
        /// <returns></returns>
        Task<Results<DeviceTypeDTO>> SketchpadByDeviceTypeName();

        /// <summary>
        /// 删除画板
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<Status> DeleteByID(string ids);


        /// <summary>
        /// 批量导出画板
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        Task<Stream> Export(string Ids);


        /// <summary>
        /// 批量导入画板
        /// </summary>
        /// <param name="zip"></param>
        /// <returns></returns>
        Task<Status> Import(ImportZip zip);

        /// <summary>
        /// 画板案例转模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Status> CaseTemplate(string id);

        /// <summary>
        /// 运维画板编辑
        /// </summary>
        /// <param name="Id">画板Id</param>
        /// <param name="Name">画板名称</param>
        /// <param name="ThreeName">关联三维模型名称</param>
        /// <param name="panoramicModel">全景模型</param>
        /// <returns></returns>
        Task<Status> Edit(string Id, string Name, string ThreeName,string TypeId,string panoramicModel);

        /// <summary>
        /// 历史画板mongo库迁移到sqlServer
        /// </summary>
        /// <returns></returns>
        Task<Status> DataMove();

    }
}
