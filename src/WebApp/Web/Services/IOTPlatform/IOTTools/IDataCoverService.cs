using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO.IOTTools;

namespace Web.Services.IOTPlatform.IOTTools
{
   public interface IDataCoverService
    {


        /// <summary>
        /// 获取历史数据信息服务
        /// </summary>
        /// <param name="ConnectionStr">数据库连接字符串</param>
        /// <param name="SiteCodes">站点编号</param>
        /// <returns></returns>
        public Task<HistoryCountReslut> HistoryInfoMation(string ConnectionStr,string SiteCodes);



       /// <summary>
       /// 历史数据转换进度
       /// </summary>
       /// <param name="keys"></param>
       /// <returns></returns>
        public Task<DataCoverResult> GetDataCover(string keys);


    }
}
