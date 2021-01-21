using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OMS.ApplicationCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Web
{
    [ApiController]
    [Route("[action]")]
    public class ConfigCenterController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;
        private readonly IWebHostEnvironment _environment;
        private AppSetting _appSetting;
        public ConfigCenterController(IOptionsMonitor<AppSetting> appConfiguration, IConfigurationService configurationService, IWebHostEnvironment environment)
        {
            _configurationService = configurationService;
            _environment = environment;
            _appSetting = appConfiguration.CurrentValue;
        }


        /// <summary>
        /// 获取是否启用网关配置
        /// </summary>
        /// <returns>是否启用网关</returns>
        [HttpGet]
        public string GateWayConfig()
        {            
              return _appSetting.IsGateWay;       
        }

        /// <summary>
        /// 微服务网关配置
        /// </summary>
        /// <param name="isOpenGateWay">是否开启网关(是，否)</param>
        /// <param name="baseUrl">微服务ip地址端口号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task MicroserviceSetting(
            [Required] string isOpenGateWay,
            [Required] string baseUrl)
        {                      
            await _configurationService.MicroserviceSetting(isOpenGateWay, baseUrl, _environment.EnvironmentName);
        }

        /// <summary>
        /// 根据配置项名称查询配置_系统信息数据
        /// </summary>
        /// <param name="moduleName">配置项名称</param>
        /// <returns></returns>
        [HttpGet]
        public Sys_Configuration SysConfiguration(string moduleName)
        {
             return _configurationService.GetSysConfigurationByModuleName(moduleName);
        }
    }
}
