using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO;
using Web.Models.Configure.Entity;
using Web.Repository;

namespace Web.Services.Configure
{
   public interface IModelService 
    {


        /// <summary>
        /// 获取模型文件
        /// </summary>
        /// <param name="dimension">维度</param>
        /// <param name="type">类型</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public Task<Results<ModelDTO>> GetModelList(string dimension, string type, string name,int pageIndex, int pageSize);

        

        /// <summary>
        /// 保存模型文件
        /// </summary>
        /// <param name="modelUpload"></param>
        /// <returns></returns>
        public Task<Status> SaveModel(ModelUpload modelUpload);


        public Task<Status> BatchSaveModel(string Type, string Dimonsion,ICollection<IFormFile> files);


        public Task<Status> DeleteByModel(string Ids);


        public Task<Results<ModelDTO>> GetModelManageList(string dimension, string type, string name, int pageIndex, int pageSize);

        public Task<Status> DataMove();

        /// <summary>
        /// 批量导出模型文件
        /// </summary>
        /// <param name="Ids">模型文件ID</param>
        /// <param name="dimonsion">维度</param>
        /// <returns></returns>
        public Task<Stream> Export(string Ids, string dimonsion);


        /// <summary>
        /// 批量导入模型文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Task<Status> Import(IFormFile file);

    }
}
