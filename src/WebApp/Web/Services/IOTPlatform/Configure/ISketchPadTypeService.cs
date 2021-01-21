using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO;
using Web.Models.Configure.Entity;

namespace Web.Services.IOTPlatform.Configure
{
   public interface ISketchPadTypeService
    {


        /// <summary>
        /// 获取画板类型列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<Results<SketchPadType>> GetTypeList(int pageSize, int pageIndex, string name);


        /// <summary>
        /// 保存模型类型
        /// </summary>
        /// <param name="modelType"></param>
        /// <returns></returns>
        public Task<Status> SaveSketchPadType(SketchPadType sketchPadType);
    }
}
