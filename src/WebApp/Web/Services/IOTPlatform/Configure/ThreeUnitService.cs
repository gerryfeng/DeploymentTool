using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO;
using Web.DTO.Configure;
using Web.Models.ThreeConfigure;
using Web.Repository;

namespace Web.Services.IOTPlatform.Configure
{
    public class ThreeUnitService : IThreeUnitService
    {

        private readonly BaseDBContext _dbContext;
        private readonly ILogger<ThreeUnitService> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ThreeUnitService(BaseDBContext dbContext, ILogger<ThreeUnitService> logger, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<Results<ModelFeature>> GetFeatureByType(string Type)
        {
            Results<ModelFeature> result = new Results<ModelFeature>();
            ModelFeature modelFeature = new ModelFeature
            {
                type = Type
            };

            string sql = string.Format(@" SELECT
                DISTINCT zm.特征
            FROM
                [组态_模型类型表] zt
                JOIN[组态_模型表] zm ON zt.类型名称 = zm.类型名称
                AND(zm.是否删除 IS NULL OR zm.是否删除 = 0)
                LEFT JOIN[组态_模型信息表] zmx ON zm.[模型名称] = zmx.[模型名称] and zm.维度 = zmx.维度
                LEFT JOIN[组态_属性表] zz ON zz.ID = zmx.属性ID
                WHERE zm.是否编辑 = '1' and ZT.类型名称 = '{0}' ",Type);
            modelFeature.feature = await Task.Run(() => _dbContext.features.FromSqlRaw(sql).ToList());

            result.getMe.Add(modelFeature);
            return result;
        }


        public async Task<Results<ModelFeatureData>> GetFeatureDataByTypeAndFeature(string Type, string Feature)
        {
            string sql = string.Format(@" SELECT ID,模型存储路径,模型名称,类型名称,特征,维度 from 组态_模型表 WHERE 是否编辑 = 1 and 是否删除 = 0 and 类型名称='{0}'", Type);
            if(!string.IsNullOrEmpty(Feature)) sql += string.Format(@" and 特征 = '{0}'", Feature);

            Results<ModelFeatureData> result = new Results<ModelFeatureData>();

            List<ModelFeatureData> list = await Task.Run(() => _dbContext.modelFeatureDatas.FromSqlRaw(sql).ToList());
            foreach (ModelFeatureData modelFeature in list)
            {
                var query = from info in _dbContext.modelInformation
                            join att in _dbContext.attributes on info.AttributeID equals att.ID
                            where info.Name.Equals(modelFeature.bfName) && info.Dimonsion.Equals(modelFeature.dimension) && att.Type.Equals(modelFeature.type)
                            select new { att.Name, info.VALUE };
                modelFeature.list = JsonConvert.SerializeObject(query.ToList());
            }
            result.getMe.AddRange(list);
            return result;
        }

        public async Task<Results<ModelFeatureData>> GetModelByDefault()
        {
            Results<ModelFeatureData> result = new Results<ModelFeatureData>();
            string sql = string.Format(@" SELECT ID,模型存储路径,模型名称,类型名称,特征,维度 from 组态_模型表 WHERE 是否编辑 = 1 and 是否删除 = 0 ");


            List<ModelFeatureData> list = await Task.Run(() => _dbContext.modelFeatureDatas.FromSqlRaw(sql).ToList());
            foreach (ModelFeatureData modelFeature in list)
            {
                var query = from info in _dbContext.modelInformation
                            join att in _dbContext.attributes on info.AttributeID equals att.ID
                            where info.Name.Equals(modelFeature.bfName) && info.Dimonsion.Equals(modelFeature.dimension) && att.Type.Equals(modelFeature.type)
                            select new { att.Name, info.VALUE };
                modelFeature.list = JsonConvert.SerializeObject(query.ToList());
            }
            result.getMe.AddRange(list);
            return result;
        }

        #region 模型场景
        public Status AddThreeSketch(ThreeSketch sketchInfo)
        {
            Status rtn = new Status()
            {
                info = "添加成功"
            };

            try
            {
                _dbContext.threeSkeths.Add(sketchInfo);
                if (_dbContext.SaveChanges() < 1)
                {
                    rtn.statusCode = "0001";
                    rtn.errMsg = "添加失败";
                }
            }
            catch (Exception ex)
            {
                rtn.statusCode = "0001";
                rtn.errMsg = $"添加失败.原因:{ex.Message}";
                _logger.LogError(rtn.errMsg);
            }

            return rtn;
        }

        public Status EditThreeSketch(ThreeSketch sketchInfo)
        {
            if (sketchInfo.ID < 1)
            {
                return new Status()
                {
                    statusCode = "0001",
                    errMsg = $"传入的id值{sketchInfo.ID} < 1"
                };
            }

            try
            {
                ThreeSketch threeSketch = _dbContext.threeSkeths.Find(sketchInfo.ID);
                if (threeSketch == null)
                {
                    return new Status()
                    {
                        statusCode = "0001",
                        errMsg = $"不存在ID为{sketchInfo.ID}的三维场景"
                    };
                }

                threeSketch.SceneInfo = sketchInfo.SceneInfo;
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                return new Status()
                {
                    statusCode = "0001",
                    errMsg = $"场景编辑失败,原因:{ex.Message}"
                };

                throw;
            }


            return new Status()
            {
                errMsg = $"场景编辑成功"
            }; 
        }
        public Results<ThreeSketch> QueryAllThreeSketch()
        {
            Results<ThreeSketch> rtn = new Results<ThreeSketch>();

            try
            {
                List<ThreeSketch> sketchList = _dbContext.threeSkeths.ToList();
                if (sketchList == null || sketchList.Count < 1)
                {
                    rtn.say.statusCode = "0000";
                    rtn.say.info = "查询结果为空";
                }
                else
                {
                    rtn.say.statusCode = "0000";
                    rtn.say.info = $"查询成功,查询到{sketchList.Count}条记录";
                    rtn.getMe.AddRange(sketchList);
                }
            }
            catch (Exception ex)
            {
                rtn.say.statusCode = "0001";
                rtn.say.errMsg = $"查询失败,原因:{ex.Message}";
                _logger.LogError(rtn.say.errMsg);
            }

            return rtn;
        }

        public Results<ThreeSketch> QueryThreeSketchById(int id)
        {
            Results<ThreeSketch> rtn = new Results<ThreeSketch>();

            if (id < 1)
            {
                rtn.say.statusCode = "0001";
                rtn.say.errMsg = $"查询失败,传入的id值为{id} < 1";
                return rtn;
            }

            try
            {
                ThreeSketch sketch = _dbContext.threeSkeths.Where(obj => obj.ID == id).FirstOrDefault();
                if (sketch == null)
                {
                    rtn.say.statusCode = "0000";
                    rtn.say.info = "查询结果为空";
                }
                else
                {
                    rtn.say.statusCode = "0000";
                    rtn.say.info = $"查询成功";
                    rtn.getMe.Add(sketch);
                }
            }
            catch (Exception ex)
            {
                rtn.say.statusCode = "0001";
                rtn.say.errMsg = $"查询失败,原因:{ex.Message}";
                _logger.LogError(rtn.say.errMsg);
            }


            return rtn;
        }

        public Status DeleteThreeSketch(string ids)
        {
            Status rtn = new Status();
            if (string.IsNullOrWhiteSpace(ids))
            {
                rtn.statusCode = "0001";
                rtn.errMsg = $"传入的id列表为空";
                return rtn;
            }

            try
            {
                string[] idList = ids.Split(',');
                List<ThreeSketch> waitRemoveItems = _dbContext.threeSkeths.Where(obj => idList.Contains(obj.ID.ToString())).ToList();
                if (waitRemoveItems == null || waitRemoveItems.Count < 1)
                {
                    rtn.statusCode = "0001";
                    rtn.errMsg = $"删除失败，根据传入ID未查询到需要删除的数据";
                    return rtn;
                }

                _dbContext.threeSkeths.RemoveRange(waitRemoveItems);

                if ( _dbContext.SaveChanges() < 1)
                {
                    rtn.statusCode = "0001";
                    rtn.errMsg = $"删除失败";
                }
                else
                {
                    rtn.statusCode = "0000";
                    rtn.info = $"删除成功";
                }
            }
            catch (Exception ex)
            {
                rtn.statusCode = "0001";
                rtn.errMsg = $"删除失败, 原因:{ex.Message}";
                _logger.LogError(rtn.errMsg);
            }

            return rtn;
        }

        #endregion

        #region 模型类型
        public Status AddThreeModelGroup(ThreeModelGroup modelGroup)
        {
            Status rtn = new Status()
            {
                info = "添加成功"
            };

            try
            {
                _dbContext.threeModelGroups.Add(modelGroup);
                if (_dbContext.SaveChanges() < 1)
                {
                    rtn.statusCode = "0001";
                    rtn.errMsg = "添加失败";
                }
            }
            catch (Exception ex)
            {
                rtn.statusCode = "0001";
                rtn.errMsg = $"添加失败.原因:{ex.Message}";
                _logger.LogError(rtn.errMsg);
            }

            return rtn;
        }

        public Results<ThreeModelGroup> QueryAllThreeModelGroup()
        {
            Results<ThreeModelGroup> rtn = new Results<ThreeModelGroup>();

            try
            {
                List<ThreeModelGroup> modelGroupList = _dbContext.threeModelGroups.ToList();
                if (modelGroupList == null || modelGroupList.Count < 1)
                {
                    rtn.say.statusCode = "0000";
                    rtn.say.info = "查询结果为空";
                }
                else
                {
                    rtn.say.statusCode = "0000";
                    rtn.say.info = $"查询成功,查询到{modelGroupList.Count}条记录";
                    rtn.getMe.AddRange(modelGroupList);
                }
            }
            catch (Exception ex)
            {
                rtn.say.statusCode = "0001";
                rtn.say.errMsg = $"查询失败,原因:{ex.Message}";
                _logger.LogError(rtn.say.errMsg);
            }

            return rtn;
        }
        public Results<ThreeModelGroup> QueryThreeModelGroupById(int id)
        {
            Results<ThreeModelGroup> rtn = new Results<ThreeModelGroup>();

            if (id < 1)
            {
                rtn.say.statusCode = "0001";
                rtn.say.errMsg = $"查询失败,传入的id值为{id} < 1";
                return rtn;
            }

            try
            {
                ThreeModelGroup modelGroup = _dbContext.threeModelGroups.Where(obj => obj.ID == id).FirstOrDefault();
                if (modelGroup == null)
                {
                    rtn.say.statusCode = "0000";
                    rtn.say.info = "查询结果为空";
                }
                else
                {
                    rtn.say.statusCode = "0000";
                    rtn.say.info = $"查询成功";
                    rtn.getMe.Add(modelGroup);
                }
            }
            catch (Exception ex)
            {
                rtn.say.statusCode = "0001";
                rtn.say.errMsg = $"查询失败,原因:{ex.Message}";
                _logger.LogError(rtn.say.errMsg);
            }


            return rtn;
        }
        
        public Status DeleteModelGroup(string ids)
        {
            Status rtn = new Status();
            if (string.IsNullOrWhiteSpace(ids))
            {
                rtn.statusCode = "0001";
                rtn.errMsg = $"传入的id列表为空";
                return rtn;
            }

            try
            {
                string[] idList = ids.Split(',');
                List<ThreeModelGroup> waitRemoveItems = _dbContext.threeModelGroups.Where(obj => idList.Contains(obj.ID.ToString())).ToList();
                if (waitRemoveItems == null || waitRemoveItems.Count < 1)
                {
                    rtn.statusCode = "0001";
                    rtn.errMsg = $"删除失败，根据传入ID未查询到需要删除的数据";
                    return rtn;
                }

                _dbContext.threeModelGroups.RemoveRange(waitRemoveItems);
                if (_dbContext.SaveChanges() < 1)
                {
                    rtn.statusCode = "0001";
                    rtn.errMsg = $"删除失败";
                }
                else
                {
                    rtn.statusCode = "0000";
                    rtn.info = $"删除成功";
                }
            }
            catch (Exception ex)
            {
                rtn.statusCode = "0001";
                rtn.errMsg = $"删除失败, 原因:{ex.Message}";
                _logger.LogError(rtn.errMsg);
            }

            return rtn;
        }
        #endregion

        #region 模型信息
        
        public Status AddThreeModel(ThreeModel threeModel)
        {
            Status rtn = new Status()
            {
                info = "新增模型成功"
            };

            if (string.IsNullOrEmpty(threeModel.Name))
            {
                rtn.errMsg = "传入名称为空";
                rtn.statusCode = "0001";
                return rtn;
            }

            if (threeModel.ModelFileData == null || threeModel.ModelFileData.Length < 1)
            {
                rtn.errMsg = "传入模型长度为0";
                rtn.statusCode = "0001";
                return rtn;
            }

            // 根据groupid 获取对应的模型分组信息
            ThreeModelGroup modelGroup = _dbContext.threeModelGroups.Find(threeModel.GroupID);
            if (modelGroup == null)
            {
                rtn.errMsg = "传入的模型分组不对";
                rtn.statusCode = "0001";
                return rtn;
            }

            // 判断模型名称是否重复
            int findCount = _dbContext.threeModel.Where(item =>
             item.Name == threeModel.Name && item.GroupID == threeModel.GroupID).Count();
            if (findCount > 0)
            {
                rtn.errMsg = "传入模型名重复";
                rtn.statusCode = "0001";
                return rtn;
            }

            if (string.IsNullOrEmpty(threeModel.Code))
                threeModel.Code = Guid.NewGuid().ToString("N");

            // 进行保存，保存的模型名字用GROUP_MODEL 暂时只支持glb模型
            string RootPath = Path.GetPathRoot(_hostingEnvironment.ContentRootPath);
            string modelDir = $@"{RootPath}\组态\三维模型";
            string filePath = $@"{modelDir}\{threeModel.Code}_{threeModel.Name}.glb";
            if (!Directory.Exists(modelDir))
                Directory.CreateDirectory(modelDir);

            // 保存模型文件

            try
            {
                IFormFile modelFile = threeModel.ModelFileData;
                if (modelFile != null)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        modelFile.CopyTo(stream);
                    }
                }
            }
            catch (Exception ex)
            {

                rtn.errMsg = $"模型保存失败.原因:{ex.Message}";
                rtn.statusCode = "0001";
                _logger.LogError(rtn.errMsg);
                return rtn;
            }

            try
            {
                _dbContext.threeModel.Add(threeModel);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                File.Delete(filePath);

                rtn.errMsg = $"模型保存失败.原因:{ex.Message}";
                rtn.statusCode = "0001";
                _logger.LogError(rtn.errMsg);
            }
           
            return rtn;
        }

        public Status DeleteThreeModel(string ids)
        {
            Status rtn = new Status();
            if (string.IsNullOrWhiteSpace(ids))
            {
                rtn.statusCode = "0001";
                rtn.errMsg = $"传入的id列表为空";
                return rtn;
            }

            try
            {
                string[] idList = ids.Split(',');
                List<ThreeModel> waitRemoveItems = _dbContext.threeModel.Where(obj => idList.Contains(obj.ID.ToString())).ToList();
                if (waitRemoveItems == null || waitRemoveItems.Count < 1)
                {
                    rtn.statusCode = "0001";
                    rtn.errMsg = $"删除失败，根据传入ID未查询到需要删除的数据";
                    return rtn;
                }

                _dbContext.threeModel.RemoveRange(waitRemoveItems);
                if (_dbContext.SaveChanges() < 1)
                {
                    rtn.statusCode = "0001";
                    rtn.errMsg = $"删除失败";
                }
                else
                {
                    rtn.statusCode = "0000";
                    rtn.info = $"删除成功";
                }
            }
            catch (Exception ex)
            {
                rtn.statusCode = "0001";
                rtn.errMsg = $"删除失败, 原因:{ex.Message}";
                _logger.LogError(rtn.errMsg);
            }

            return rtn;
        }

        public Results<Stream>ExportModel(long id)
        {
            Results<Stream> rtn = new Results<Stream>();

            //MemoryStream rtn = new MemoryStream();

            // 查询模型信息
            if (id < 1)
            {
                rtn.say.statusCode = "0001";
                rtn.say.errMsg = $"查询失败,传入的id值为{id} < 1";
                return rtn;
            }

            ThreeModel threeModel = _dbContext.threeModel.Find(id);
            if (threeModel == null)
            {
                rtn.say.statusCode = "0001";
                rtn.say.errMsg = $"查询结果未空,不存在id为{id}的模型";
                return rtn;
            }

            string RootPath = Path.GetPathRoot(_hostingEnvironment.ContentRootPath);
            string modelDir = $@"{RootPath}\组态\三维模型";
            string filePath = $@"{modelDir}\{threeModel.Code}_{threeModel.Name}.glb";

            if (!File.Exists(filePath))
            {
                rtn.say.statusCode = "0001";
                rtn.say.errMsg = $"模型文件在服务器上不存在";
                return rtn;
            }

            string cacheDir = $@"{modelDir}\cache";
            if (!Directory.Exists(cacheDir))
                Directory.CreateDirectory(cacheDir);
            
            string cacheFilePath = $@"{cacheDir}\{threeModel.Code}_{threeModel.Name}.glb";

            // 文件拷贝 防止同时访问导致访问失败
            File.Copy(filePath, cacheFilePath);
            if (File.Exists(cacheFilePath))
            {
                rtn.say.statusCode = "0001";
                rtn.say.errMsg = $"模型文件{threeModel.Code}_{threeModel.Name}拷贝到缓存目录失败";
                return rtn;
            }

            rtn.getMe.Add(new FileStream(cacheFilePath, FileMode.Open, FileAccess.Read));
            File.Delete(cacheFilePath);

            return rtn;
        }

        public Results<ModelResult> QueryAllThreeModel()
        {
            Results<ModelResult> rtn = new Results<ModelResult>();

            try
            {
                var query = from groupInfo in _dbContext.Set<ThreeModelGroup>()
                            join modelInfo in _dbContext.Set<ThreeModel>()
                            on groupInfo.ID equals modelInfo.GroupID into grouping
                            from modelInfo in grouping.DefaultIfEmpty()
                            select new ModelResult
                            {
                                ID = modelInfo.ID,
                                Name = modelInfo.Name,
                                DisplayName = modelInfo.DisplayName,
                                Code = modelInfo.Code,
                                GroupID = modelInfo.GroupID,
                                Attribute = modelInfo.Attribute,
                                AinimationID = modelInfo.AinimationID,
                                CreateTime = modelInfo.CreateTime,
                                CreateUser = modelInfo.CreateUser,
                                GroupName = groupInfo.Name,
                                GroupCode = groupInfo.Code,
                                AttributeIDs = groupInfo.AttributeIDs
                            };

                List<ModelResult> modelGroupList = query.ToList();
                if (modelGroupList == null || modelGroupList.Count < 1)
                {
                    rtn.say.statusCode = "0000";
                    rtn.say.info = "查询结果为空";
                }
                else
                {
                    rtn.say.statusCode = "0000";
                    rtn.say.info = $"查询成功,查询到{modelGroupList.Count}条记录";
                    rtn.getMe.AddRange(modelGroupList);
                }
            }
            catch (Exception ex)
            {
                rtn.say.statusCode = "0001";
                rtn.say.errMsg = $"查询失败,原因:{ex.Message}";
                _logger.LogError(rtn.say.errMsg);
            }

            return rtn;
        }

        public Results<ModelResult> QueryThreeModelByGroup(long groupID)
        {
            Results<ModelResult> rtn = new Results<ModelResult>();

            try
            {
                var query = from groupInfo in _dbContext.Set<ThreeModelGroup>()
                            join modelInfo in _dbContext.Set<ThreeModel>()
                            on new { id = groupInfo.ID, parentID = groupInfo.ID } equals
                             new {id = modelInfo.GroupID, parentID = groupID }
                             into grouping
                            from modelInfo in grouping.DefaultIfEmpty()
                            select new ModelResult
                            {
                                ID = modelInfo.ID,
                                Name = modelInfo.Name,
                                DisplayName = modelInfo.DisplayName,
                                Code = modelInfo.Code,
                                GroupID = modelInfo.GroupID,
                                Attribute = modelInfo.Attribute,
                                AinimationID = modelInfo.AinimationID,
                                CreateTime = modelInfo.CreateTime,
                                CreateUser = modelInfo.CreateUser,
                                GroupName = groupInfo.Name,
                                GroupCode = groupInfo.Code,
                                AttributeIDs = groupInfo.AttributeIDs
                            };

                List<ModelResult> modelGroupList = query.ToList();
                if (modelGroupList == null || modelGroupList.Count < 1)
                {
                    rtn.say.statusCode = "0000";
                    rtn.say.info = "查询结果为空";
                }
                else
                {
                    rtn.say.statusCode = "0000";
                    rtn.say.info = $"查询成功,查询到{modelGroupList.Count}条记录";
                    rtn.getMe.AddRange(modelGroupList);
                }
            }
            catch (Exception ex)
            {
                rtn.say.statusCode = "0001";
                rtn.say.errMsg = $"查询失败,原因:{ex.Message}";
                _logger.LogError(rtn.say.errMsg);
            }

            return rtn;
        }
        #endregion
    }
}
