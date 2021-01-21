using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO;
using Web.Models.Configure.Entity;
using Web.Repository;

namespace Web.Services.Configure.Services
{
    public interface IModelTypeService:IRepository<ModelType>
    {

       /// <summary>
       /// 获取模型类型管理列表
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       public Task<Results<ModelTypeDTO>> GetTypeList(int pageSize, int pageIndex,string name);

        /// <summary>
        /// 获取模型文件类型信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<Results<ModelType>> GetList(ModelType model);

        /// <summary>
        /// 保存模型类型
        /// </summary>
        /// <param name="modelType"></param>
        /// <returns></returns>
        public Status SaveModelType(string name,string creator);

    }
}
