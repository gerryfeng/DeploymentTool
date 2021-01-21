using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Repository
{
   public interface IMongoRepository
    {

        public ObjectId GetInternalId(string id);
        

        public Task<GridFSFileInfo> GetFileById(string id);

        public Task<GridFSFileInfo> GetFileById(ObjectId id);

        /// <summary>
        /// 获取文件内容
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<byte[]> DownloadAsBytesByName(string fileName);


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public Task<ObjectId> UploadFile(string fileName, Stream source);


        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<GridFSDownloadStream<ObjectId>> DownloadFileStreamSeekable(string id);



        public Task<GridFSDownloadStream<ObjectId>> DownloadFileStreamSeekable(ObjectId id);


        public  Task<GridFSDownloadStream<ObjectId>> DownloadFileStream(string id);


        public Task<GridFSDownloadStream<ObjectId>> DownloadFileStream(ObjectId id);

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteFile(string id);

        public  Task DeleteFile(ObjectId id);

        public  Task RenameFile(string id, string newFilename);


        public  Task RenameFile(ObjectId id, string newFilename);
        


    }
}
