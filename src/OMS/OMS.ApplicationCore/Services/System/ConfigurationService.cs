using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public class ConfigurationService: IConfigurationService
    {
        public readonly ISysConfRepository _sysConfRepository;
        public ConfigurationService(ISysConfRepository sysConfRepository)
        {
            _sysConfRepository = sysConfRepository;
        }

        /// <summary>
        /// 微服务网关配置
        /// </summary>
        /// <param name="isOpenGateWay">是否开启网关(是，否)</param>
        /// <param name="baseUrl">微服务ip地址端口号</param>
        /// <returns></returns>
        public async Task MicroserviceSetting(string isOpenGateWay,string baseUrl,string environmentName)
        {
            Sys_Configuration sysConfig =_sysConfRepository.GetModel(x => x.ModuleName == "是否启用网关");
            if(sysConfig != null)
            {
                if (isOpenGateWay.Trim() == sysConfig.Value.Trim())
                {
                    throw new Exception($"网关已为{(isOpenGateWay == "是" ? "开启" : "关闭")}状态！");
                }
                else
                {
                    sysConfig.Value = isOpenGateWay.Trim();
                    _sysConfRepository.Update(sysConfig);
                    return;
                }
            }
            await _sysConfRepository.AddAsync(new Sys_Configuration()
            {
                ModuleName = "是否启用网关",
                PModuleName = "微服务配置",
                Description = "OMS系统部署时是否启用网关",
                IsEnable = 1,
                Value = isOpenGateWay,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            });

            //修改微服务配置文件端口
            ConfigBridge.ConfigBridge config = new ConfigBridge.ConfigBridge(environmentName == "Development");
            config.DeserializeConnConfig();
            string jsonPath = config.AppSolutionPath;

            string omsJsonPath = jsonPath+ "\\NetConfigs\\OMS\\appsettings.json";
            Oms_AppSettings oms_AppSettings = JsonConvert.DeserializeObject<Oms_AppSettings>(File.ReadAllText(omsJsonPath));
            string identityServerUrl = oms_AppSettings.AppSetting.IdentityServerUrl;
            oms_AppSettings.AppSetting.IdentityServerUrl = baseUrl + "/"+ identityServerUrl.Substring(identityServerUrl.LastIndexOf("Publish"));
            File.WriteAllText(omsJsonPath,JsonConvert.SerializeObject(oms_AppSettings));
            
        }

        public Sys_Configuration GetSysConfigurationByModuleName(string moduleName)
        {
            if (string.IsNullOrEmpty(moduleName))
            {
                return null;
            }
            return _sysConfRepository.GetModel(x => x.ModuleName == moduleName);
        }
    }
}
