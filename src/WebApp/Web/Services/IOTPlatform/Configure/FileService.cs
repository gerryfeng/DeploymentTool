using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DTO;
using Web.Models.Configure;
using Web.Repository;

namespace Web.Services.Configure
{
    public class FileService : IFileService
    {
        private readonly BaseDBContext dbContext;
        private readonly ILogger<FileService> logger;

        public FileService(BaseDBContext _dbContext, ILogger<FileService> _logger)
        {
            dbContext = _dbContext;
            logger = _logger;
        }


        /// <summary>
        /// 获取模型文件内容
        /// </summary>
        /// <param name="dimonsion"></param>
        /// <param name="type"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<byte[]> GetModelAsBytes(string dimonsion, string type, string fileName)
        {
            string file = dimonsion + @"\" + type + @"\" + fileName;

            if (string.IsNullOrEmpty(dimonsion) && string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(fileName)) file = fileName;

            string sql = string.Format("select top 1 ID,模型文件 from 组态_模型表 where ( 是否删除 = 0 or 是否删除 is null ) and 模型存储路径 = '{0}' ", file);

            ModelImage modelImage = dbContext.modelImages.FromSqlRaw(sql).ToList().FirstOrDefault();
            if(modelImage!=null && modelImage.bytes!=null && modelImage.bytes.Length>0) return await Task.Run(() =>modelImage.bytes);
            else return new byte[0];
        }

        /// <summary>
        ///  获取画板图片
        /// </summary>
        /// <param name="dimonsion"></param>
        /// <param name="siteCode"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<byte[]> GetSketchAsBytes(string dimonsion, string siteCode, string fileName)
        {
            string file = dimonsion + @"\" + siteCode + @"\" + fileName;
            string sql = string.Format("select top 1 ID, 画板图片 from 组态_画板 where 是否删除 = 0 and 缩略图Url = '{0}' ", file);

            SketchPadImage sketchPad = dbContext.sketchPadImages.FromSqlRaw(sql).ToList().FirstOrDefault();
            if (sketchPad != null && sketchPad.bytes!=null && sketchPad.bytes.Length > 0) return await Task.Run(() => sketchPad.bytes);
            else return new byte[0];
        }

        /// <summary>
        /// 获取画板json
        /// </summary>
        /// <param name="dimonsion"></param>
        /// <param name="siteCode"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> GetSketchAsContent(string dimonsion, string siteCode, string fileName)
        {
            string result = string.Empty;
            string file =  siteCode + @"\" + fileName;

            string sql = string.Format("select top 1 ID,画板名称,热度,画板Json from 组态_画板 where 是否删除 = 0 and 配置文件Url = '{0}' ", file);
            //更新画板热度
            SketchPadJson sketchPadJson = await Task.Run(() => dbContext.sketchPadJsons.FromSqlRaw(sql).AsNoTracking().FirstOrDefault());
            if (sketchPadJson != null) 
            {
                int number = 0;
                if (sketchPadJson.Heat != null) number = Convert.ToInt32(sketchPadJson.Heat);
                string updateSql = $"update 组态_画板 set 热度 = '{number+1}' where ID = '{sketchPadJson.ID}'";
                dbContext.sketchPadJsons.FromSqlRaw(updateSql);
            }
            if (sketchPadJson != null && sketchPadJson.bytes!=null && sketchPadJson.bytes.Length > 0)
                return Encoding.UTF8.GetString(sketchPadJson.bytes);
            else return result;
        }
    }
}
