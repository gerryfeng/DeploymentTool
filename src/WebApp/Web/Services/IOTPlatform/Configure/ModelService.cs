using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DTO;
using Web.DTO.Configure;
using Web.Models.Configure.Entity;
using Web.Repository;
using Web.Utils;
using Web.Utils.Configure;

namespace Web.Services.Configure
{
    public class ModelService : IModelService
    {

        private readonly BaseDBContext dbContext;
        private readonly ILogger<ModelService> _logger;
        private IWebHostEnvironment _hostingEnvironment { get; }

        public ModelService(BaseDBContext _dBContext, ILogger<ModelService> logger, IWebHostEnvironment hostingEnvironment)
        {
            dbContext = _dBContext;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<byte[]> GetByteFile(string name)
        {
            return await Task.Run(() => dbContext.models.Where(x => x.Name.Equals(name)).ToList().FirstOrDefault().ModelFile) ;
        }


        /// <summary>
        /// 获取模型列表
        /// </summary>
        /// <param name="dimension">维度</param>
        /// <param name="type">类型</param>
        /// <param name="name">模型名称</param>
        /// <param name="pageIndex">起始页</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public async Task<Results<ModelDTO>> GetModelList(string dimension, string type, string name, int pageIndex, int pageSize)
        {
            Results<ModelDTO> result = new Results<ModelDTO>();
            result.currentPageIndex = pageIndex;

            StringBuilder sb = new StringBuilder();
            sb.Append(@"
	                    SELECT
		                    model.ID,
		                    mtype.类型名称,
		                    model.模型名称,
		                    model.图标路径,
		                    model.模型存储路径,
		                    model.模型长宽高,
		                    model.维度,
		                    model.创建人,
		                    model.[是否删除],
		                    model.创建日期,
	                        ISNULL(model.模型维度关联,0) 模型维度关联,
                            model.材质文件路径
	                    FROM
		                    组态_模型类型表 mtype
		                    JOIN 组态_模型表 model ON mtype.类型名称 = model.类型名称 and (model.是否删除 != 1 OR model.是否删除 IS NULL)
	                    WHERE model.是否编辑= 0 ");

            List <ModelQueryDTO> list = await Task.Run(() => dbContext.modelQueryDTOs.FromSqlRaw(sb.ToString()).ToList());
            List<ModelQueryDTO> resultList = list.Where(x => x.RealModel == 0).ToList();
               
            if (!"全部".Equals(dimension) && !string.IsNullOrEmpty(dimension))
                resultList = resultList.Where(x => x.Dimonsion == dimension).ToList();

            if (!"全部".Equals(type) && !string.IsNullOrEmpty(type))
                resultList = resultList.Where(x => x.TypeName == type).ToList();

            if (!string.IsNullOrEmpty(name))
                resultList = resultList.Where(x =>x.Name.Contains(name)).ToList();

            //递归父节点查找子集
            foreach (ModelQueryDTO model in resultList)
                model.children.AddRange(GetChildren(model.ID, list));

            result.totalRcdNum = resultList.Count();
            result.getMe = resultList.GroupBy(x => x.TypeName).Select(x => new ModelDTO { Type = x.Key, list = x.OrderBy(it => it.Name).ToList() }).ToList();

            return result;
        }


        /// <summary>
        /// 保存模型文件
        /// </summary>
        /// <param name="modelUpload"></param>
        /// <returns></returns>
        public async Task<Status> SaveModel(ModelUpload modelUpload)
        {
            Status result = new Status();

            string RootPath = Path.GetPathRoot(_hostingEnvironment.ContentRootPath);
            string filePath = RootPath + @"组态\组态模型文件\" + modelUpload.Dimension + @"\";

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            //根据模型名称,维度,类型名称,是否编辑判断模型是否存在
            List<Model> list = dbContext.models.AsNoTracking().Where(m => (
                   m.IsDelete == 0 || string.IsNullOrEmpty(m.IsDelete.ToString()))
                   && m.Name.Equals(modelUpload.Name)
                   && m.Dimonsion.Equals(modelUpload.Dimension)
                   && m.TypeName.Equals(modelUpload.Type)
                   && m.IsEdit == 0
               ).ToList();

            //保存模型文件到本地
            var path = "";
            IFormFile modelFile = modelUpload.ModelFile;
            if (modelFile!=null && modelUpload.ModelFile.Length>0) {
                path = filePath + modelFile.FileName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await modelFile.CopyToAsync(stream);
                }
            }

            if (!string.IsNullOrEmpty(modelUpload.Attr) && !"[]".Equals(modelUpload.Attr))
            {
                //判断模型属性是否存在
                var qury = from t1 in dbContext.modelInformation
                           join t2 in dbContext.attributes
                           on t1.AttributeID equals t2.ID
                           where t1.Name == modelUpload.Name
                           && t1.Dimonsion == modelUpload.Dimension
                           && t2.Type == modelUpload.Type
                           select new ModelInfoAttr
                           {
                               ID = t1.ID,
                               Name = t1.Name,
                               Dimonsion = t1.Dimonsion,
                               AttributeID = t1.AttributeID,
                               VALUE = t1.VALUE,
                               AttributeName = t2.Name,
                               AttributeType = t2.Type
                           };

                List<ModelInfoAttr> ls = qury.ToList();
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    foreach (ModelInfoAttr attr in ls)
                    {
                        //删除原有属性
                        ModelAttribute attribute = new ModelAttribute();
                        attribute.ID = attr.AttributeID;
                        dbContext.attributes.Remove(attribute);
                        dbContext.SaveChanges();

                        ModelInformation information = new ModelInformation();
                        information.ID = attr.ID;
                        dbContext.modelInformation.Remove(information);
                        dbContext.SaveChanges();
                    }
                    transaction.Commit();

                    //保存属性信息
                    try
                    {
                        JObject jo = (JObject)JsonConvert.DeserializeObject(modelUpload.Attr);
                        foreach (JProperty item in jo.Children())
                        {
                            ModelAttribute at = new ModelAttribute
                            {
                                Type = modelUpload.Type,
                                Name = item.Name
                            };

                            dbContext.attributes.Add(at);
                            dbContext.SaveChanges();

                            at = dbContext.attributes.Where(x => x.Name.Equals(item.Name) && x.Type.Equals(modelUpload.Type)).ToList().FirstOrDefault();

                            ModelInformation inf = new ModelInformation
                            {
                                AttributeID = at.ID,
                                Dimonsion = modelUpload.Dimension,
                                VALUE = item.Value.ToString(),
                                Name = modelUpload.Name
                            };

                            dbContext.modelInformation.Add(inf);
                            dbContext.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.ToString());
                        result.info = "保存失败";
                        result.errMsg = "保存失败:" + e.ToString();
                    }
                }
            }

            int realID = 0;// 模型关联Id
            if (!string.IsNullOrEmpty(modelUpload.RelModel) && !"null".Equals(modelUpload.RelModel))
            {
                Model mo = dbContext.models.Where(x => x.ID.ToString() == modelUpload.RelModel).FirstOrDefault();
                if (mo == null)
                {
                    result.statusCode = "001";
                    result.errMsg = "关联模型有误！！！";
                    return result;
                }
                else 
                {
                    realID = mo.ID;
                }
            }

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (list.Count() > 0)
                    {
                        //更新模型文件
                        Model m = list.FirstOrDefault();
                        if (!string.IsNullOrEmpty(modelUpload.Size))
                            m.Size = modelUpload.Size;

                        if (modelUpload.IsEdit > 0)
                        {
                            m.IsEdit = modelUpload.IsEdit;
                        }

                        if (realID > 0) m.RealModel = realID;

                        if (modelUpload.ModelFile != null && modelUpload.ModelFile.Length > 0)
                        {
                            using (FileStream fsRead = new FileStream(path, FileMode.Open))
                            {
                                int fsLen = (int)fsRead.Length;
                                byte[] heByte = new byte[fsLen];
                                fsRead.Read(heByte, 0, heByte.Length);
                                m.ModelFile = heByte;
                            }
                        }

                        dbContext.models.Attach(m);
                        dbContext.Entry(m).State = EntityState.Modified;
                        dbContext.SaveChanges();
                        transaction.Commit();
                        result.info = "编辑成功";
                        return result;
                    }

                    Model model = new Model
                    {
                        Name = modelUpload.Name,
                        TypeName = modelUpload.Type,
                        Dimonsion = modelUpload.Dimension,
                        ModelPath = modelUpload.Dimension + @"\" + modelUpload.Type + @"\" + modelUpload.ModelFile?.FileName,
                        Size = modelUpload.Size,
                        createTime = DateTime.Now,
                        people = modelUpload.CreateBy,
                    };

                    if (realID > 0) model.RealModel = realID;

                    if (modelUpload.ModelFile != null && modelUpload.ModelFile.Length > 0)
                    {
                        using (FileStream fsRead = new FileStream(path, FileMode.Open))
                        {
                            int fsLen = (int)fsRead.Length;
                            byte[] heByte = new byte[fsLen];
                            fsRead.Read(heByte, 0, heByte.Length);
                            model.ModelFile = heByte;
                        }
                    }
                    dbContext.models.Add(model);
                    dbContext.SaveChanges();
                    transaction.Commit();
                    result.info = "保存成功";
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex.ToString());
                    result.info = "保存失败";
                    result.statusCode = "0001";
                    result.errMsg = "保存失败:" + ex.ToString();
                }
            }

            return result;
        }


        /// <summary>
        /// 批量保存模型文件
        /// </summary>
        /// <param name="batchImport"></param>
        /// <returns></returns>
        public async Task<Status> BatchSaveModel(string Type, string Dimonsion, ICollection<IFormFile> files)
        {
            Status result = new Status();

            string RootPath = Path.GetPathRoot(_hostingEnvironment.ContentRootPath);
            string filePath = RootPath + @"组态\组态模型文件\" + Dimonsion + @"\";
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    //判断模型类型是否存在,不存在保存类型
                   int count = dbContext.modelTypes.Where(t => t.Name.Equals(Type)).ToList().Count();
                    if (count<=0) {
                        ModelType type = new ModelType
                        {
                            Name =Type,
                            CreateTime = DateTime.Now,
                        };

                        dbContext.modelTypes.Add(type);
                        dbContext.SaveChanges();
                    }

                    //保存模型文件到本地
                    var path = "";
                    if (files != null && files.Count > 0)
                    {
                        foreach (IFormFile file in files)
                        {
                            path = filePath + (file.FileName.Split("/").Length>1? file.FileName.Split("/")[1]: file.FileName);
                            if (!File.Exists(path)) {
                                //判断模型是否存在
                                int num = dbContext.models.Where(m => m.Name.Equals(file.FileName) &&
                                m.Dimonsion.Equals(Dimonsion) && (m.IsDelete == 0 || string.IsNullOrEmpty(m.IsDelete.ToString()) 
                                && m.TypeName.Equals(Type))).ToList().Count();

                                if (num > 0) continue;
                                
                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    await file.CopyToAsync(stream);
                                }

                                Model model = new Model
                                {
                                    Name = (file.FileName.Split("/").Length > 1 ? file.FileName.Split("/")[1].Split('.')[0] : file.FileName.Split('.')[0]),
                                    TypeName = Type,
                                    Dimonsion = Dimonsion,
                                    ModelPath = Dimonsion + "\\" + Type + "\\" + (file.FileName.Split("/").Length > 1 ? file.FileName.Split("/")[1] : file.FileName),
                                    createTime = DateTime.Now,
                                };

                                //读取文件内容
                                string JsonStr = "";
                                if (file.FileName.EndsWith("svg"))
                                {
                                    string width = "";
                                    string height = "";

                                    string content = File.ReadAllText(path);
                                    CommonUtils.getSvgWH(content, out width, out height);

                                    SVGWidthJson json = new SVGWidthJson
                                    {
                                        width = width,
                                        height = height
                                    };
                                    JsonStr = JsonConvert.SerializeObject(json);
                                }

                                if (!string.IsNullOrEmpty(JsonStr)) model.Size = JsonStr;

                                if (file!= null && file.Length > 0)
                                {
                                    using (FileStream fsRead = new FileStream(path, FileMode.Open))
                                    {
                                        int fsLen = (int)fsRead.Length;
                                        byte[] heByte = new byte[fsLen];
                                        fsRead.Read(heByte, 0, heByte.Length);
                                        model.ModelFile = heByte;
                                    }
                                }

                                dbContext.models.Add(model);
                                dbContext.SaveChanges();
                                result.info = "保存成功";
                            }
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex.ToString());
                    result.statusCode = "0001";
                    result.info = "保存失败";
                    result.errMsg = "保存失败:" + ex.ToString();
                }
            }

            return result;
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="Ids">模型ID</param>
        /// <returns></returns>
        public async Task<Status> DeleteByModel(string Ids)
        {
            Status result = new Status();
            string sql = $"select * from 组态_模型表 where (是否删除 != 1 OR 是否删除 IS NULL) and 模型维度关联 in( {string.Join(",",Ids.Split(',').Select(o => $"'{o}'").ToList())} )";
            List<ModelQueryDTO> list = await Task.Run(() => dbContext.modelQueryDTOs.FromSqlRaw(sql.ToString()).ToList());
            if (list.Count>0) 
            {
                result.statusCode = "0001";
                result.info = "模型下有子模型,请先删除子模型";
                return result;
            }

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    string[] id = Ids.Split(',');
                    foreach (string str in id) {
                        Model model = dbContext.models.AsNoTracking().Where(m => m.ID.ToString() == str ).FirstOrDefault();
                        if (model!=null) {
                            model.IsDelete = 1;
                            dbContext.models.Attach(model);
                            dbContext.Entry(model).State = EntityState.Modified;
                            dbContext.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex.ToString());
                    result.info = "删除失败";
                    result.statusCode = "0001";
                    result.errMsg = "删除失败:" + ex.ToString();
                }
            }
            return result;
        }



        public async Task<Results<ModelDTO>> GetModelManageList(string dimension, string type, string name, int pageIndex, int pageSize)
        {
            Results<ModelDTO> result = new Results<ModelDTO>();
            result.currentPageIndex = pageIndex;

            StringBuilder sb = new StringBuilder();
            sb.Append(@"
	                    SELECT
		                    model.ID,
		                    mtype.类型名称,
		                    model.模型名称,
		                    model.图标路径,
		                    model.模型存储路径,
		                    model.模型长宽高,
		                    model.维度,
		                    model.创建人,
		                    model.[是否删除],
		                    model.创建日期,
                            ISNULL(model.模型维度关联,0) 模型维度关联,
                            model.材质文件路径
	                    FROM
		                    组态_模型类型表 mtype
		                    JOIN 组态_模型表 model ON mtype.类型名称 = model.类型名称 and (model.是否删除 != 1 OR model.是否删除 IS NULL)
	                    WHERE 1=1 ");

            if (!"全部".Equals(dimension) && !string.IsNullOrEmpty(dimension))
                sb.Append(string.Format(" and model.维度='{0}' ", dimension));

            if (!"全部".Equals(type) && !string.IsNullOrEmpty(type))
                sb.Append(string.Format("and mtype.类型名称='{0}' ", type));

            List<ModelQueryDTO> list = await Task.Run(() => dbContext.modelQueryDTOs.FromSqlRaw(sb.ToString()).ToList());

            

            List <ModelQueryDTO> resultList = list.Where(x=>x.RealModel==0).ToList();

            foreach (ModelQueryDTO queryDTO in resultList) 
            {
                queryDTO.children.AddRange(GetChildren(queryDTO.ID, list));

                if (!queryDTO.Dimonsion.Equals("三维")) continue;
                var query = from info in dbContext.modelInformation
                            join att in dbContext.attributes on info.AttributeID equals att.ID
                            where info.Name.Equals(queryDTO.Name) && info.Dimonsion.Equals(queryDTO.Dimonsion) && att.Type.Equals(queryDTO.TypeName)
                            select new { att.Name, info.VALUE };

                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (var item in query.ToList())
                    dictionary.Add(item.Name, item.VALUE);

                List<Dictionary<string, string>> propertyResult = new List<Dictionary<string, string>>();
                propertyResult.Add(dictionary);
                queryDTO.property = JsonConvert.SerializeObject(propertyResult) ;
            }

            if (!string.IsNullOrEmpty(name))
                resultList = resultList.Where(x => x.Name.Contains(name)).ToList();

            result.getMe = resultList.GroupBy(x => x.TypeName).Select(x => new ModelDTO { Type = x.Key, list = x.OrderBy(it => it.Name).ToList() }).ToList();

            return result;
        }

        public async Task<Status> DataMove()
        {
            Status result = new Status();

            //获取运维mongodb配置
            ConfigBridge.ConfigBridge config = new ConfigBridge.ConfigBridge(_hostingEnvironment.IsDevelopment());
            config.DeserializeConnConfig();

            MongoRepository mongoRepository = null;

            try
            {
                mongoRepository = new MongoRepository(config.connConfig.mongo.Value);
            }
            catch (Exception e)
            {
                result.errMsg = "获取mongoDB数据库实例异常:" + e.ToString();
                result.statusCode = "0001";
                return result;
            }

            List<Model> modelsList = await Task.Run(() => dbContext.models.AsNoTracking().Where(s => s.IsDelete == 0 && s.ModelFile == null).ToList());
                try
                {
                    foreach (Model model in modelsList)
                    {
                        if (model.ModelFile != null) continue;
                        try {
                            model.ModelFile = await Task.Run(() => mongoRepository.DownloadAsBytesByName(model.ModelPath));
                            dbContext.models.Attach(model);
                            dbContext.Entry(model).State = EntityState.Modified;
                            dbContext.SaveChanges();
                        } catch (Exception e) { 

                        }
                    }
                    result.info = "批量转换成功";
                }
                catch (Exception e)
                {
                    result.errMsg = "批量转换失败 " + e.ToString();
                    result.statusCode = "0001";
                    return result;
                }
            return result;
        }

        public async Task<Stream> Export(string Ids, string dimonsion)
        {
            MemoryStream ms = new MemoryStream();
            string RootPath = Path.GetPathRoot(_hostingEnvironment.ContentRootPath);
            string Guid = System.Guid.NewGuid().ToString("N");
            string filePath = RootPath + @"组态\"+ Guid+ @"\"+ dimonsion + @"\";
            string zipPath = RootPath + @"组态\"+ Guid + ".zip";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            Ids = string.Join(",", Ids.Split(',').Select(tn => $"'{tn}'"));
            string sql = string.Format("select ID,模型名称,模型存储路径,类型名称,模型文件 from 组态_模型表 where 是否删除 = 0 and ID in ({0}) and 维度='{1}' ", Ids, dimonsion);

            List<ExportModel> exportModels = await Task.Run(() => dbContext.exportModels.FromSqlRaw(sql).ToList());
            foreach (ExportModel model in exportModels)
            {
                //获取文件后缀
                string extension = System.IO.Path.GetExtension(model.ModelPath);

                string fileName = filePath + model.Name + "&&&"+ model.TypeName + "&&&" + extension;
                if (model.ModelFile == null) continue;

                using (FileStream fsWrite = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    fsWrite.Write(model.ModelFile, 0, model.ModelFile.Length);
                }
            }

            filePath = RootPath + @"组态\" + Guid;
            //生成Zip包
            bool sucess = ZipClass.ZipFile(filePath, zipPath);
            if (sucess)
            {
                FileUtils.DeleteFolder(filePath);
                return new FileStream(zipPath, FileMode.Open, FileAccess.Read);
            }
            else
            {
                return new MemoryStream(ms.ToArray());
            }
        }

        public async Task<Status> Import(IFormFile files)
        {

            Status result = new Status();
            string RootPath = Path.GetPathRoot(_hostingEnvironment.ContentRootPath);
            string ParentPath = RootPath + @"组态\导入模型\";

            if (files == null || files.Length <= 0)
            {
                result.statusCode = "0001";
                result.errMsg = "上传文件不能为空!,请选择压缩文件";
                return result;
            }
            else if (!files.FileName.EndsWith(".zip"))
            {
                result.statusCode = "0001";
                result.errMsg = "上传文件格式异常,请选择zip包";
                return result;
            }

            string path = ParentPath + files.FileName;
            string unZipPath = ParentPath + Path.GetFileNameWithoutExtension(path);
            if (!Directory.Exists(unZipPath))
            {
                Directory.CreateDirectory(unZipPath);
            }

            if (files != null && files.Length > 0)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await files.CopyToAsync(stream);
                }
            }

            //解压zip文件
            bool sucess = ZipClass.unZipFile(path, unZipPath);
            if (!sucess)
            {
                result.statusCode = "0001";
                result.errMsg = "zip包解压异常";
                return result;
            }

            //获取解压目录子文件夹名称
            string Dimonsion = Path.GetFileNameWithoutExtension(Directory.GetDirectories(unZipPath)[0]);

            List<Model> list = dbContext.models.Where(x => x.Dimonsion == Dimonsion && ( x.IsDelete == 0 || string.IsNullOrEmpty(x.IsDelete.ToString()))).ToList();

            List<string> existType = dbContext.modelTypes.Select(t => t.Name).ToList();

            List<string> typeList = new List<string>(); //模型类型

            var modelfiles = Directory.GetFiles(Directory.GetDirectories(unZipPath)[0]);

            //遍历文件,跟新数据库信息
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    List<string> Names = list.Select(x => x.Name  +"&&&" + x.TypeName + "&&&" + Path.GetExtension(x.ModelPath)).Distinct().ToList();
                    foreach (var file in modelfiles)
                    {
                        if (!Names.Contains(Path.GetExtension(file)))
                        {
                            Model model = new Model
                            {
                                Name = Path.GetFileName(file).Split("&&&")[0],
                                TypeName = Path.GetFileName(file).Split("&&&")[1],
                                Dimonsion = Dimonsion,
                                ModelPath = Dimonsion + "\\"+ Path.GetFileName(file).Split("&&&")[1]+"\\" + Path.GetFileName(file).Split("&&&")[0] + Path.GetExtension(file),
                                createTime = DateTime.Now,
                            };

                            if (!typeList.Contains(Path.GetFileName(file).Split("&&&")[1]))
                                typeList.Add(Path.GetFileName(file).Split("&&&")[1]);

                            string JsonStr = "";
                            if (file.EndsWith("svg"))
                            {
                                string width = "";
                                string height = "";

                                string content = File.ReadAllText(file);
                                CommonUtils.getSvgWH(content, out width, out height);

                                SVGWidthJson json = new SVGWidthJson
                                {
                                    width = width,
                                    height = height
                                };
                                JsonStr = JsonConvert.SerializeObject(json);
                            }

                            if (!string.IsNullOrEmpty(JsonStr)) model.Size = JsonStr;

                            if (file != null && file.Length > 0)
                            {
                                using (FileStream fsRead = new FileStream(file, FileMode.Open))
                                {
                                    int fsLen = (int)fsRead.Length;
                                    byte[] heByte = new byte[fsLen];
                                    fsRead.Read(heByte, 0, heByte.Length);
                                    model.ModelFile = heByte;
                                }
                            }

                            dbContext.models.Add(model);
                            dbContext.SaveChanges();
                        }
                    }
                    transaction.Commit();
                    result.info = "保存成功";
                    result.statusCode = "0000";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError(ex.ToString());
                    result.statusCode = "0001";
                    result.info = "保存失败";
                    result.errMsg = "保存失败:" + ex.ToString();
                }

            }

            List<string> newType = typeList.Except(existType).ToList();
            foreach (string type in newType) 
            {
                ModelType modelType = new ModelType
                {
                    Name = type,
                    CreateTime = DateTime.Now
                };
                dbContext.modelTypes.Add(modelType);
                dbContext.SaveChanges();
            }

            //删除zip和解压目录
            FileUtils.DeleteFolder(unZipPath);
            File.Delete(path);

            return result;
        }


        private List<ModelQueryDTO> GetChildren(int Id, List<ModelQueryDTO> models)
        {
            List<ModelQueryDTO> childrenList = models.Where(x=>x.RealModel == Id).ToList();
            if (childrenList.Count == 0)
               return childrenList;

            foreach (ModelQueryDTO m in childrenList)
            {
                m.children.AddRange(GetChildren(m.ID,models));
            }
            return childrenList;
        }

    }
}
