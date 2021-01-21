
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web.DTO;
using Web.Models.Configure.Entity;
using Web.Repository;
using Web.Repository.Configure;

namespace Web.Services.Configure.Services
{
    public class ModelTypeService : Repository<ModelType>,IModelTypeService
    {

        private readonly BaseDBContext baseDBContext;
        private readonly ILogger<ModelTypeService> _logger;

        public ModelTypeService(BaseDBContext dBContext, ILogger<ModelTypeService> logger) : base(dBContext)
        {
            baseDBContext = dBContext;
            _logger = logger;
        }


        /// <summary>
        ///  获取
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Results<ModelTypeDTO>> GetTypeList(int pageSize, int pageIndex, string name)
        {
            Results<ModelTypeDTO> result = new Results<ModelTypeDTO>();
            pageIndex = pageIndex ==0 ? 1 : pageIndex;

            result.currentPageIndex = pageIndex;

            Expression<Func<ModelType, bool>> expression =
               t => t.Name.Contains(name);

            var query = GetModelsByPage(Convert.ToInt32(pageSize), Convert.ToInt32(pageIndex), false, t => t.ID, expression);

            var list = from t1 in baseDBContext.modelTypes //获取模型类型表
                       join t2 in
                       (
                            from a in baseDBContext.models.Where(m => (m.IsDelete != 1 || string.IsNullOrEmpty(m.IsDelete.ToString())) && m.IsEdit == 0)//筛选模型表模型未删除并且是否编辑为0的
                             from e in baseDBContext.modelTypes
                            where e.Name == a.TypeName
                            group e by e.Name into g
                            select new
                            {
                                Name = g.Key,
                                Count = g.Count()
                            }
                         )

                       on t1.Name equals t2.Name into temp

                       from t3 in temp.DefaultIfEmpty()

                       select new ModelTypeDTO()
                       {
                           ID = t1.ID,
                           Name = t1.Name,
                           NumBer = t3.Count,
                           People = t1.Founder,
                           CreateTime = t1.CreateTime,
                       };
           
            result.getMe = await Task.Run(() => list.ToList());
            result.totalRcdNum = Count(expression);
            return result;
        }

        /// <summary>
        /// 获取所有模型类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Results<ModelType>> GetList(ModelType model)
        {
            Results<ModelType> result = new Results<ModelType>();
            var TypeResult = await Task.Run(() => baseDBContext.modelTypes.ToList());
            if (!string.IsNullOrEmpty(model.Name)) TypeResult = TypeResult.Where(x => x.Name == model.Name).ToList();
            result.getMe.AddRange(TypeResult);
            return result;
        }



        public Status SaveModelType(string Name,string creator)
        {
            Status status = new Status();
            try
            {
                List<ModelType> list = baseDBContext.modelTypes.AsNoTracking().Where(m => m.Name.Equals(Name) ).ToList();
                if (list.Count > 0) 
                {
                    status.statusCode = "0001";
                    status.errMsg = "类型名称已重复";
                    return status;
                }

                ModelType type = new ModelType();
                type.Name = Name;
                type.Founder = creator;
                type.CreateTime = DateTime.Now;
                baseDBContext.modelTypes.Add(type);
                if (baseDBContext.SaveChanges() > 0) status.info = "保存成功";
                return status;
            }  catch (Exception e) {
                status.statusCode = "0001";
                status.errMsg = "保存失败！！！";
                _logger.LogError("保存失败" + e.ToString());
                return status;
            }
           
        }
    }
}
