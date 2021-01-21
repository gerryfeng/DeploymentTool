using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DTO.IOTTools;
using Web.Services.IOTPlatform.IOTTools;

namespace Web.Controllers.IOTPlatform.IOTTools
{
    [Route("[controller]")]
    [ApiController]
    public class HistoryConvertController : ControllerBase
    {
        private readonly IDataCoverService dataCoverService;
        // Data Source=192.168.19.105;Initial Catalog=Panda_ceshi;User ID=sa;Password=sa

        public HistoryConvertController(IDataCoverService coverService) {
            dataCoverService = coverService;
        }

        /// <summary>
        /// 物联工具历史数据历史表信息服务
        /// </summary>
        /// <param name="ConnectionStr">数据库连接字符串</param>
        /// <returns></returns>
        [HttpGet("history/HistoryInfoMation")]
        public async Task<ActionResult> HistoryInfoMation(string ConnectionStr,string siteCodes)
        {
            return Ok(await dataCoverService.HistoryInfoMation(ConnectionStr, siteCodes)); 
        }


        /// <summary>
        /// 历史数据转换进度
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        [HttpGet("history/GetDataCover")]
        public async Task<ActionResult> GetDataCover(string keys)
        {
            return Ok(await dataCoverService.GetDataCover(keys));
        }

    }
}