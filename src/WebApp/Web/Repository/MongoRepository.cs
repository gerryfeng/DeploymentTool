using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Repository
{ 
    public class MongoRepository:IMongoRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _db;
        private readonly IGridFSBucket bucket;

        //注入相关配置
        public MongoRepository(string ConnectionStrings)
        {
            //获取mongodb连接信息及数据库
            string ConnStr = ConnectionStrings.Split("?")[0].ToString();
            int endIndex = ConnStr.LastIndexOf("/");
            string ip = ConnStr.Substring(0,endIndex);
            string dbName = ConnStr.Substring(endIndex+1);
            _client = new MongoClient(ip);
            _db = _client.GetDatabase(dbName);
            bucket = new GridFSBucket(_db);

        }

        public ObjectId GetInternalId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId internalId))
                internalId = ObjectId.Empty;
            return internalId;
        }

        public async Task<GridFSFileInfo> GetFileById(string id)
        {
            var filter = Builders<GridFSFileInfo>.Filter.Eq("_id", GetInternalId(id));
            return await bucket.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<GridFSFileInfo> GetFileById(ObjectId id)
        {
            var filter = Builders<GridFSFileInfo>.Filter.Eq("_id", id);
            return await bucket.Find(filter).FirstOrDefaultAsync();
        }

        //上传文件
        public async Task<ObjectId> UploadFile(string fileName, Stream source)
        {
            var id = await bucket.UploadFromStreamAsync(fileName, source);
            return id;
        }

        //下载文件
        public async Task<GridFSDownloadStream<ObjectId>> DownloadFileStreamSeekable(string id)
        {
            var options = new GridFSDownloadOptions
            {
                Seekable = true
            };
            return await bucket.OpenDownloadStreamAsync(GetInternalId(id), options);
        }

        public async Task<GridFSDownloadStream<ObjectId>> DownloadFileStreamSeekable(ObjectId id)
        {
            var options = new GridFSDownloadOptions
            {
                Seekable = true
            };
            return await bucket.OpenDownloadStreamAsync(id, options);
        }

        public async Task<GridFSDownloadStream<ObjectId>> DownloadFileStream(string id)
        {
            return await bucket.OpenDownloadStreamAsync(GetInternalId(id));
        }

        public async Task<GridFSDownloadStream<ObjectId>> DownloadFileStream(ObjectId id)
        {
            return await bucket.OpenDownloadStreamAsync(id);
        }

        public async Task DeleteFile(string id)
        {
            await bucket.DeleteAsync(GetInternalId(id));
        }

        public async Task DeleteFile(ObjectId id)
        {
            await bucket.DeleteAsync(id);
        }

        public async Task RenameFile(string id, string newFilename)
        {
             await bucket.RenameAsync(GetInternalId(id), newFilename);
        }

        public async Task RenameFile(ObjectId id, string newFilename)
        {
             await bucket.RenameAsync(id, newFilename);
        }


        /// <summary>
        /// 根据文件名称获取文件内容
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<byte[]> DownloadAsBytesByName(string fileName)
        {
           return await bucket.DownloadAsBytesByNameAsync(fileName);
        }
    }
}
