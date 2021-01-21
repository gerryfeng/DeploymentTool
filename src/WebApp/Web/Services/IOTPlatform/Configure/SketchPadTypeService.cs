using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO;
using Web.Models.Configure.Entity;
using Web.Repository;

namespace Web.Services.IOTPlatform.Configure
{
    public class SketchPadTypeService : ISketchPadTypeService
    {

        private readonly BaseDBContext baseDBContext;
        private readonly ILogger<SketchPadTypeService> _logger;

        public SketchPadTypeService(BaseDBContext dBContext, ILogger<SketchPadTypeService> logger)
        {
            baseDBContext = dBContext;
            _logger = logger;
        }

        public async Task<Results<SketchPadType>> GetTypeList(int pageSize, int pageIndex, string name)
        {
            Results<SketchPadType> result = new Results<SketchPadType>();
            List<SketchPadType> list = baseDBContext.sketchPadTypes.ToList();
            if (list.Count > 0)
                result.getMe = list;
            return result;
        }

        public async Task<Status> SaveSketchPadType(SketchPadType sketchPadType)
        {
            Status result = new Status();
            if (sketchPadType.ID > 0)
            {
                try
                {
                    SketchPadType sketch = await Task.Run(()=> baseDBContext.sketchPadTypes.AsNoTracking().Where(m => m.ID == sketchPadType.ID).FirstOrDefault());
                    sketch.Name = sketchPadType.Name;
                    baseDBContext.sketchPadTypes.Attach(sketch);
                    baseDBContext.Entry(sketch).State = EntityState.Modified;
                    baseDBContext.SaveChanges();
                    result.info = "编辑成功";
                }
                catch (Exception e)
                {
                    result.statusCode = "0001";
                    result.errMsg = "编辑失败！！！";
                    _logger.LogError("编辑失败" + e.ToString());
                    return result;
                }
            }
            else
            {
                try
                {
                    baseDBContext.sketchPadTypes.Add(sketchPadType);
                    if (baseDBContext.SaveChanges() > 0) result.info = "保存成功";
                    return result;
                }
                catch (Exception e)
                {
                    result.statusCode = "0001";
                    result.errMsg = "保存失败！！！";
                    _logger.LogError("保存失败" + e.ToString());
                    return result;
                }
            }
            return result;
        }
    }
}
