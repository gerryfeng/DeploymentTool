using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Svg;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DTO;
using Web.DTO.Configure;
using Web.Models.Configure;
using Web.Models.Configure.Entity;
using Web.Repository;
using Web.Repository.Configure;
using Web.Utils;
using Web.Utils.Configure;

namespace Web.Services.Configure.Services
{
    public class SketchpadService : ISketchpadService
    {

        private readonly BaseDBContext dbContext;
        private readonly ILogger<SketchpadService> _logger;
        private IWebHostEnvironment _hostingEnvironment { get; }

        public SketchpadService(BaseDBContext _dBContext, ILogger<SketchpadService> logger, IWebHostEnvironment hostingEnvironment)
        {
            dbContext = _dBContext;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<Status> DeleteByID(string Ids)
        {
            Status result = new Status();
            string[] id = Ids.Split(',');
            foreach (string i in id)
            {
                Sketchpad sketchpad = await Task.Run(() => dbContext.sketchpads.Where(x => x.ID.ToString().Equals(i)).ToList().FirstOrDefault());
                if (sketchpad != null)
                {
                    sketchpad.IsDelete = 1;
                    dbContext.sketchpads.Attach(sketchpad);
                    dbContext.Entry(sketchpad).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
                result.info = "删除成功";
            }
            return result;
        }


        public async Task<Results<SketchpadDetailListDTO>> GetPointDetails()
        {
            Results<SketchpadDetailListDTO> result = new Results<SketchpadDetailListDTO>();
            List<PointAddress> list = await Task.Run(() => dbContext.pointAddresses.ToList());
            foreach (PointAddress point in list)
            {
                SketchpadDetailListDTO listDTO = new SketchpadDetailListDTO
                {
                    Id = point.ID.ToString(),
                    Name = point.FVersion,
                    Version = point.FName + "." + point.FVersion
                };
                listDTO.list = await Task.Run(() => dbContext.pointAddressesEntry.Where(x => x.VersionID == point.ID).ToList());
                result.getMe.Add(listDTO);
            }
            return result;
        }

        public async Task<Results<QuerySketch>> GetSketchpadList(int pageIndex, int pageSize, string siteCode,
              int isTemplate, string name, string dimension, string queryInfo, string siteInfo, int typeID,string version)
        {

            Results<QuerySketch> result = new Results<QuerySketch>();
            result.currentPageIndex = pageIndex;

            StringBuilder sb = new StringBuilder();
            sb.Append(@" select [ID], [画板名称], [维度], [摄相机XYZ], [配置文件Url], [点表版本], [是否模板], [缩略图Url], [关联三维模型名称], [是否删除], [站点个数],
                      [siteCode], [站点信息], [类型ID],[热度],[项目简称],[是否样板],[全景模型],[版本] from 组态_画板 where 是否删除 = 0 ");

            if (string.IsNullOrEmpty(dimension)) dimension = "二维";

            if (!"全部".Equals(dimension) && !string.IsNullOrEmpty(dimension))
                sb.Append(string.Format(" and 维度='{0}' ", dimension));

            if (!string.IsNullOrEmpty(name))
                sb.Append(string.Format(" and 画板名称 = '{0}' ", name));

            if (isTemplate > 0)
                sb.Append(string.Format(" and 是否模板 = '{0}' ", isTemplate));

            if (!string.IsNullOrEmpty(siteCode))
                sb.Append(string.Format(" and siteCode = '{0}' ", siteCode));

            if (!string.IsNullOrEmpty(siteInfo))
                sb.Append(string.Format(" and 站点信息 = '{0}' ", siteInfo));

            if (!string.IsNullOrEmpty(queryInfo))
                sb.Append(string.Format(" and 画板名称 like '%{0}%' ", queryInfo));

            if (typeID > 0)
                sb.Append(string.Format(" and 类型ID = '{0}'  ", typeID));

            if(!string.IsNullOrEmpty(version)&&!"全部".Equals(version))
                sb.Append(string.Format(" and 版本 = '{0}'  ", version));

            if(string.IsNullOrEmpty(version))
                sb.Append(string.Format(" and ( 版本 is null or 版本='') "));

            try 
            {
                result.totalRcdNum = dbContext.querySketches.FromSqlRaw(sb.ToString()).ToList().Count();
            } catch (Exception e) 
            {
                result.say.statusCode = "0001";
                result.say.errMsg = $"请检查OMS数据库是否升级:{e.Message}";
                return result;
            }
            

            if (pageSize > 0 && pageIndex > 0)
            {
                int nStartNum = pageSize * (pageIndex - 1) + 1;
                int nEndNum = pageSize * pageIndex + 1;
                sb = new StringBuilder(PageQuerySql.GetPagedQuerySql(sb.ToString(), "ID", nStartNum, nEndNum, true));
            }

            sb.Append(" order by 热度 desc ");
            result.getMe = await Task.Run(() => dbContext.querySketches.FromSqlRaw(sb.ToString()).ToList());

            return result;
        }

        /// <summary>
        /// 保存画板
        /// </summary>
        /// <param name="sketchPadDTO"></param>
        /// <returns></returns>
        public async Task<Status> SaveSketchPad(SketchPadSaveDTO sketchPadDTO)
        {
            Status result = new Status();

            string RootPath = Path.GetPathRoot(_hostingEnvironment.ContentRootPath);
            string filePath = RootPath + @"组态\组态模板文件\" + sketchPadDTO.Dimonsion + @"\";
            string path = filePath + sketchPadDTO.siteCode + @"\";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //判断画板名称是否存在
            int number = dbContext.sketchpads.Where(s =>
             s.Name.Equals(sketchPadDTO.Name) && !s.SiteCode.Equals(sketchPadDTO.siteCode)
             && s.IsDelete == 0
             ).ToList().Count();
            if (number > 0)
            {
                result.errMsg = "画板名称已存在,请修改画板名称!!!";
                result.statusCode = "0001";
                return result;
            }

            string JsonPath = path + sketchPadDTO.Name + ".json";
            //画板Json
            byte[] bytes = Encoding.UTF8.GetBytes(sketchPadDTO.jsonStr);
            using (FileStream fsWrite = new FileStream(JsonPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                fsWrite.Write(bytes, 0, bytes.Length);
            }

            //保存svg文件
            string svgPath = path + sketchPadDTO.Name + ".svg";
            byte[] byteArray = Encoding.UTF8.GetBytes(sketchPadDTO.data);
            File.WriteAllBytes(svgPath, byteArray);

            try
            {
                string pngPath = path + sketchPadDTO.Name + ".png";
                //转换图片
                try
                {
                    await Task.Run(() => FileUtils.SvgToPicture(pngPath, sketchPadDTO.data));
                    _logger.LogInformation("组态画板图片生成成功 ");
                }
                catch (Exception e)
                {
                    _logger.LogError("组态画板图片生成异常: " + e.Message);
                }

                List<Sketchpad> list = dbContext.sketchpads.AsNoTracking().Where(s =>
                s.Name.Equals(sketchPadDTO.Name) && s.SiteCode.Equals(sketchPadDTO.siteCode)
                && s.IsDelete == 0
                ).ToList();

                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        if (list.Count > 0)
                        {
                            //修改
                            Sketchpad sketchpad = list.FirstOrDefault();
                            if (!string.IsNullOrEmpty(sketchPadDTO.Name))
                                sketchpad.Name = sketchPadDTO.Name;

                            if (!string.IsNullOrEmpty(sketchPadDTO.Dimonsion))
                                sketchpad.Dimonsion = sketchPadDTO.Dimonsion;

                            if (!string.IsNullOrEmpty(sketchPadDTO.jsonStr))
                                sketchpad.DeployURL = sketchPadDTO.siteCode + @"\" + sketchPadDTO.Name + ".json";

                            if (!string.IsNullOrEmpty(sketchPadDTO.pointVersion))
                                sketchpad.PointVersion = sketchPadDTO.pointVersion;

                            if (!string.IsNullOrEmpty(sketchPadDTO.isTemplate.ToString()))
                                sketchpad.IsTemplate = sketchPadDTO.isTemplate > 0 ? true : false;

                            if (!string.IsNullOrEmpty(sketchPadDTO.num.ToString()))
                                sketchpad.Num = sketchPadDTO.num;

                            if (!string.IsNullOrEmpty(sketchPadDTO.ThreeDimonsionName))
                                sketchpad.ThreeDimonsionName = sketchPadDTO.ThreeDimonsionName;

                            if (!string.IsNullOrEmpty(sketchPadDTO.data) && File.Exists(pngPath))
                                sketchpad.images = FileUtils.SaveImage(pngPath);

                            if (!string.IsNullOrEmpty(sketchPadDTO.data))
                                sketchpad.ThumbnailURL = sketchPadDTO.Dimonsion + @"\" + sketchPadDTO.siteCode + @"\" + sketchPadDTO.Name + ".png";

                            if (!string.IsNullOrEmpty(sketchPadDTO.siteCode))
                                sketchpad.SiteCode = sketchPadDTO.siteCode;

                            if (!string.IsNullOrEmpty(sketchPadDTO.siteInfo))
                                sketchpad.SiteInfo = sketchPadDTO.siteInfo;

                            if (!string.IsNullOrEmpty(sketchPadDTO.jsonStr))
                                sketchpad.Json = Encoding.UTF8.GetBytes(sketchPadDTO.jsonStr);

                            if (!string.IsNullOrEmpty(sketchPadDTO.TypeID.ToString()))
                                sketchpad.TypeID = sketchPadDTO.TypeID;

                            if (!string.IsNullOrEmpty(sketchPadDTO.ProjectName))
                                sketchpad.projectName = sketchPadDTO.ProjectName;

                            if (!string.IsNullOrEmpty(sketchPadDTO.Templet.ToString()))
                                sketchpad.Templet = sketchPadDTO.Templet;

                            if (!string.IsNullOrEmpty(sketchPadDTO.Version))
                                sketchpad.Version = sketchPadDTO.Version;

                            dbContext.sketchpads.Attach(sketchpad);
                            dbContext.Entry(sketchpad).State = EntityState.Modified;
                            dbContext.SaveChanges();
                            transaction.Commit();
                            result.info = "编辑成功";
                        }
                        else
                        {
                            Sketchpad sketchpad = new Sketchpad
                            {
                                Name = sketchPadDTO.Name,
                                Dimonsion = sketchPadDTO.Dimonsion,
                                DeployURL = sketchPadDTO.siteCode + @"\" + sketchPadDTO.Name + ".json",
                                PointVersion = sketchPadDTO.pointVersion,
                                IsTemplate = sketchPadDTO.isTemplate > 0 ? true : false,
                                Num = sketchPadDTO.num,
                                ThumbnailURL = sketchPadDTO.Dimonsion + @"\" + sketchPadDTO.siteCode + @"\" + sketchPadDTO.Name + ".png",
                                SiteCode = sketchPadDTO.siteCode,
                                SiteInfo = sketchPadDTO.siteInfo,
                                Json = bytes,
                                TypeID = sketchPadDTO.TypeID
                            };
                            if (!string.IsNullOrEmpty(sketchPadDTO.ProjectName))
                                sketchpad.projectName = sketchPadDTO.ProjectName;

                            if (!string.IsNullOrEmpty(sketchPadDTO.data) && File.Exists(pngPath)) 
                            {
                                try 
                                {
                                    sketchpad.images = FileUtils.SaveImage(pngPath);
                                } catch (Exception e)
                                {
                                    _logger.LogError("新增画板图片异常:"+e.Message);
                                }
                            }
                                

                            if (!string.IsNullOrEmpty(sketchPadDTO.Templet.ToString()))
                                sketchpad.Templet = sketchPadDTO.Templet;

                            if (!string.IsNullOrEmpty(sketchPadDTO.Version))
                                sketchpad.Version = sketchPadDTO.Version;

                            dbContext.sketchpads.Add(sketchpad);
                            dbContext.SaveChanges();
                            transaction.Commit();
                            result.info = "保存成功";
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _logger.LogError("异常：" + ex.Message);
                        result.info = "保存失败";
                        result.statusCode = "0001";
                        result.errMsg = "保存失败:" + ex.Message;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return result;
        }

        public async Task<Results<DeviceTypeDTO>> SketchpadByDeviceTypeName()
        {
            Results<DeviceTypeDTO> result = new Results<DeviceTypeDTO>();

            List<DeviceType> list = await Task.Run(() => dbContext.deviceTypes.ToList());

            foreach (DeviceType type in list)
            {

                DeviceTypeDTO dTO = new DeviceTypeDTO
                {
                    Type = type.Type
                };

                if (string.IsNullOrEmpty(type.AddressName)) continue;

                List<PointAddress> points = await Task.Run(() => dbContext.pointAddresses.Where(a => (!string.IsNullOrEmpty(a.FName)) && a.FName == type.AddressName).ToList());

                List<string> lis = new List<string>();
                foreach (PointAddress p in points)
                {
                    lis.Add(type.AddressName + "." + p.FVersion + (string.IsNullOrEmpty(p.FNote) ? "" : "(" + p.FNote + ")"));
                }

                dTO.list = lis;
                result.getMe.Add(dTO);
            }

            return result;
        }


        /// <summary>
        /// 导出模型文件
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public async Task<Stream> Export(string Ids)
        {
            MemoryStream ms = new MemoryStream();
            string RootPath = Path.GetPathRoot(_hostingEnvironment.ContentRootPath);
            string Guid = System.Guid.NewGuid().ToString("N");
            string filePath = RootPath + @"组态\组态模板文件\" + Guid + @"\";
            string zipPath = RootPath + @"组态\组态模板文件\" + Guid + ".zip";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            Ids = string.Join(",", Ids.Split(',').Select(tn => $"'{tn}'"));
            string sql = string.Format("select ID, 画板名称, 画板图片, 画板Json from 组态_画板 where 是否删除 = 0 and ID in ({0}) ", Ids);

            try 
            {
                List<ExportSkpad> exportSkpadsList = await Task.Run(() => dbContext.exportSkpads.FromSqlRaw(sql).ToList());
                foreach (ExportSkpad json in exportSkpadsList)
                {
                    //生成画板json文件
                    string fileName = filePath + json.Name + ".json";
                    string png = filePath + json.Name + ".png";

                    Byte[] bytes = json?.bytes;
                    Byte[] images = json?.images;

                    if (bytes == null || bytes != null && bytes.Length == 0)
                        continue;

                    using (FileStream fsWrite = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        fsWrite.Write(bytes, 0, bytes.Length);
                    }

                    if (images != null && images.Length > 0)
                    {
                        using (FileStream fsPngWrite = new FileStream(png, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                        {
                            fsPngWrite.Write(images, 0, images.Length);
                        }
                    }

                }

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
            } catch (Exception e) 
            {
                _logger.LogError("画板批量导出异常：" + e.Message);
            }
            return new MemoryStream(ms.ToArray());

        }

        public async Task<Status> Import([FromForm]ImportZip zip)
        {
            Status result = new Status();
            string RootPath = Path.GetPathRoot(_hostingEnvironment.ContentRootPath);
            string ParentPath = RootPath + @"组态\组态模板文件\";

            IFormFile files = zip.file;
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

            List<Sketchpad> list = dbContext.sketchpads.Where(x => x.IsDelete == 0 || string.IsNullOrEmpty(x.IsDelete.ToString())).ToList();

            //遍历文件,跟新数据库信息
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var jsonfiles = Directory.GetFiles(unZipPath, "*.json");
                    List<string> Names = list.Select(x => x.Name).Distinct().ToList();
                    foreach (var file in jsonfiles)
                    {
                        if (!Names.Contains(Path.GetFileNameWithoutExtension(file)))
                        {
                            Sketchpad sketchpad = new Sketchpad
                            {
                                Name = Path.GetFileNameWithoutExtension(file),
                                Dimonsion = "二维",
                                DeployURL = zip.siteCode + @"\" + Path.GetFileNameWithoutExtension(file) + ".json",
                                SiteCode = zip.siteCode,
                                Json = Encoding.UTF8.GetBytes(File.ReadAllText(file)),
                            };
                            //读取图片
                            string pngPath = file.Replace(".json", ".png");
                            if (File.Exists(pngPath))
                            {
                                sketchpad.images = FileUtils.SaveImage(pngPath);
                                sketchpad.ThumbnailURL = @"二维\" + zip.siteCode + @"\" + Path.GetFileNameWithoutExtension(file) + ".png";
                            }
                            dbContext.sketchpads.Add(sketchpad);
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

            //删除zip和解压目录
            FileUtils.DeleteFolder(unZipPath);
            File.Delete(path);

            return result;
        }



        /// <summary>
        /// 将一个文件夹的内容读取为 Stream 的压缩包
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="stream"></param>
        public static async Task ReadDirectoryToZipStreamAsync(DirectoryInfo directory, Stream stream)
        {
            var fileList = directory.GetFiles();

            using var zipArchive = new ZipArchive(stream, ZipArchiveMode.Create);
            foreach (var file in fileList)
            {
                var relativePath = file.FullName.Replace(directory.FullName, "");
                if (relativePath.StartsWith("\\") || relativePath.StartsWith("//"))
                {
                    relativePath = relativePath.Substring(1);
                }

                var zipArchiveEntry = zipArchive.CreateEntry(relativePath, CompressionLevel.NoCompression);

                using (var entryStream = zipArchiveEntry.Open())
                {
                    using var toZipStream = file.OpenRead();
                    await toZipStream.CopyToAsync(stream);
                }
                await stream.FlushAsync();
            }
        }


        /// <summary>
        /// 运维画板转模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Status> CaseTemplate(string id)
        {
            Status result = new Status();
            try
            {
                Sketchpad sketchpad = await Task.Run(() => dbContext.sketchpads.AsNoTracking().Where(s => s.ID.ToString() == id).FirstOrDefault());
                if (sketchpad != null)
                {
                    sketchpad.Templet = 1;
                    dbContext.sketchpads.Attach(sketchpad);
                    dbContext.Entry(sketchpad).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    result.info = "保存成功";
                }
            }
            catch (Exception e)
            {
                result.errMsg = "保存失败" + e.ToString();
                result.statusCode = "0001";
            }
            return result;
        }

        public async Task<Status> Edit(string Id, string Name, string ThreeName, string TypeId,string panoramicModel)
        {
            Status result = new Status();
            try
            {
                Sketchpad sketchpad = await Task.Run(() => dbContext.sketchpads.AsNoTracking().Where(s => s.ID.ToString() == Id).FirstOrDefault());
                if (sketchpad != null)
                {
                    if (!string.IsNullOrEmpty(Name)) sketchpad.Name = Name;
                    if (!string.IsNullOrEmpty(ThreeName)) sketchpad.ThreeDimonsionName = ThreeName;
                    if (!string.IsNullOrEmpty(TypeId)) sketchpad.TypeID = Convert.ToInt32(TypeId);
                    if (!string.IsNullOrEmpty(panoramicModel)) sketchpad.panoramicModel = panoramicModel;
                    dbContext.sketchpads.Attach(sketchpad);
                    dbContext.Entry(sketchpad).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    result.info = "编辑成功";
                }
            }
            catch (Exception e)
            {
                result.errMsg = "编辑失败" + e.ToString();
                result.statusCode = "0001";
            }
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

            List<Sketchpad> sketchpadList = await Task.Run(() => dbContext.sketchpads.AsNoTracking().Where(s => s.IsDelete == 0).ToList());

            try
            {
                foreach (Sketchpad sketchpad in sketchpadList)
                {
                    using (var transaction = dbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            if (sketchpad.Json != null) continue;

                            sketchpad.Json = await mongoRepository.DownloadAsBytesByName(sketchpad.DeployURL);
                            try
                            {
                                sketchpad.images = await mongoRepository.DownloadAsBytesByName(sketchpad.ThumbnailURL);
                            }
                            catch (Exception e)
                            {
                            }

                            dbContext.sketchpads.Attach(sketchpad);
                            dbContext.Entry(sketchpad).State = EntityState.Modified;
                            dbContext.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();

                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.errMsg = "批量转换失败 " + e.ToString();
                result.statusCode = "0001";
                return result;
            }

            return result;
        }
    }
}
