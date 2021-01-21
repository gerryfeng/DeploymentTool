using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OMS.ApplicationCore;

namespace OMS.Web
{
    /// <summary>
    /// 文件中心
    /// </summary>
    public class FileCenterController : BaseApiController
    {
        private IWebHostEnvironment _environment { get; }

        private readonly IFileService _fileService;

        public FileCenterController(IWebHostEnvironment hostingEnvironment, IFileService fileService)
        {
            _environment = hostingEnvironment;
            _fileService = fileService;
        }

        /// <summary>
        /// 单文件上传
        /// </summary>
        /// <param name="singleFile">文件</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> UploadSingleFile([Required] IFormFile singleFile)
        {
            if (singleFile == null || singleFile.Length == 0)
            {
                throw new Exception("请上传图片");
            }

            string rootPath = ConfigBridge.ConfigBridge.CityTempPath(_environment.IsDevelopment());

            string tempPath = @$"\图库\{DateTime.Now.ToString("yyyyMMdd")}\";
            if (!Directory.Exists(rootPath + tempPath))
                Directory.CreateDirectory(rootPath + tempPath);

            string fullPath = rootPath + tempPath + singleFile.FileName;

            if (!System.IO.File.Exists(fullPath))
            {
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await singleFile.CopyToAsync(stream);
                }
            }          
            return "CityTemp" + tempPath + singleFile.FileName;
        }

        /// <summary>
        /// 获取文件路径
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <remarks>
        /// moduleName 可选 CityTemp\icon\androidMenu\menuNew\logo\menu 支持多选用逗号隔开
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public List<FileModel> GetFileUrls([Optional] string moduleName)
        {
            List<FileModel> list = new List<FileModel>();
            if (!string.IsNullOrWhiteSpace(moduleName) && moduleName.Contains("CityTemp"))
            {
                string rootPath = ConfigBridge.ConfigBridge.CityTempPath(_environment.IsDevelopment(), "CityTemp//图库");
                FileModel m = new FileModel() { moduleName = "CityTemp" };
                _fileService.FindFile(new DirectoryInfo(rootPath), m, "CityTemp");
                list.Add(m);
            }

            string rootPath2 = ConfigBridge.ConfigBridge.CityTempPath(_environment.IsDevelopment(), "Web4//assets//images//");
            if (string.IsNullOrWhiteSpace(moduleName) || moduleName.Contains("icon"))
            {
                FileModel m = new FileModel() { moduleName = "icon" };
                _fileService.FindFile(new DirectoryInfo(rootPath2 + m.moduleName), m, "Web4");
                list.Add(m);
            }
            if (string.IsNullOrWhiteSpace(moduleName) || moduleName.Contains("androidMenu"))
            {
                FileModel m = new FileModel() { moduleName = "androidMenu" };
                _fileService.FindFile(new DirectoryInfo(rootPath2 + m.moduleName), m, "Web4");
                list.Add(m);
            }
            if (string.IsNullOrWhiteSpace(moduleName) || moduleName.Contains("menuNew"))
            {
                FileModel m = new FileModel() { moduleName = "menuNew" };
                _fileService.FindFile(new DirectoryInfo(rootPath2 + m.moduleName), m, "Web4");
                list.Add(m);
            }
            if (string.IsNullOrWhiteSpace(moduleName) || moduleName.Contains("logo"))
            {
                FileModel m = new FileModel() { moduleName = "logo" };
                _fileService.FindFile(new DirectoryInfo(rootPath2 + m.moduleName), m, "Web4");
                list.Add(m);
            }
            if (string.IsNullOrWhiteSpace(moduleName) || moduleName.Contains("menu"))
            {
                FileModel m = new FileModel() { moduleName = "menu" };
                _fileService.FindFile(new DirectoryInfo(rootPath2 + m.moduleName), m, "Web4");
                list.Add(m);
            }
            return list;
        }

        /// <summary>
        /// 保存小程序apk文件
        /// </summary>
        /// <param name="file">文件上传</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task SaveMobileApk(
            [Required] IFormFile file, 
            [FromForm] ApkUploadModel model)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("请上传apk文件！");
            }

            if(model == null || string.IsNullOrWhiteSpace(model.description))
            {
                throw new Exception("请输入描述字段！");
            }           
            string rootPath = ConfigBridge.ConfigBridge.CityTempPath(_environment.IsDevelopment(), @"BufFile\Mobile\APK\"+model.client);
            if (!Directory.Exists(rootPath))
                Directory.CreateDirectory(rootPath);
            else
            { 
                foreach(string f in Directory.GetFiles(rootPath))
                {
                    System.IO.File.Delete(f);
                }
            }

            string fullPath = rootPath + @"\"+ file.FileName;
            string jsonPath = rootPath + @"\" + Path.GetFileNameWithoutExtension(file.FileName) + ".json";

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            model.apkPath = @"BufFile\Mobile\APK\" + model.client + @"\" + file.FileName;
            model.updateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            using (FileStream fs = new FileStream(jsonPath, FileMode.Create))
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using(StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    await sw.WriteAsync(JsonConvert.SerializeObject(model));
                }
            }           
        }


        /// <summary>
        /// 获取移动应用上传apk信息
        /// </summary>
        /// <param name="apkName">apk文件名</param>
        /// <param name="client">client标识</param>
        /// <returns></returns>
        [HttpGet]
        public ApkUploadModel GetMobileFiles( [Required] string client)
        {
            ApkUploadModel model = new ApkUploadModel();
            
            string filePath = ConfigBridge.ConfigBridge.CityTempPath(_environment.IsDevelopment(), @"BufFile\Mobile\APK\" + client );

            FileInfo[] files= new DirectoryInfo(filePath).GetFiles();
            if (files?.Length == 0)
            {
                throw new Exception("请检测文件是否存在：" + filePath);
            }
            string jsonName = "";
            for(int i=0; i< files.Length; i++)
            {
                if( Path.GetExtension(files[i].Name) == ".json")
                {
                    jsonName = files[i].FullName;
                    break;
                }
            }

            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
               
            using(StreamReader file = System.IO.File.OpenText(jsonName))
            {
                using(JsonTextReader reader = new JsonTextReader(file))
                {
                    model = serializer.Deserialize<ApkUploadModel>(reader);
                }
            }         
            return model;
        }

    }
}
