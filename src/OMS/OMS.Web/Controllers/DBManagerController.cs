using AutoMapper;
using ConfigBridge;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OMS.ApplicationCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System;
using OMS.Infrastructure;

namespace OMS.Web
{
    /// <summary>
    /// 数据库管理
    /// </summary>
    public class DBManagerController : BaseApiController
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger<DBManagerController> _logger;

        public DBManagerController(
            IConfiguration configuration, 
            ILogger<DBManagerController> logger, 
            IMapper mapper) 
        {
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;       
        }

        /// <summary>
        /// 数据库测试连接
        /// </summary>
        /// <param name="ip">ip地址</param>
        /// <param name="dbName">数据库名</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpGet]
        public async Task ConnectionTest(
            [Required] string ip, 
            [Required] string dbName, 
            [Required] string userName, 
            [Required] string password)
        {
            if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(dbName) || string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("数据库连接参数不全");
            }

            string errMsg = "";
            bool flag = await Task.Run(() => SqlHelper.ConnectionTest(ip, dbName, userName, password, out errMsg));

            if (!flag)
            {
                throw new Exception(errMsg);
            }
        }
    }
}
