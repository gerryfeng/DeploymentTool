using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMS.ApplicationCore
{
    public interface IConfigurationService
    {
        Task MicroserviceSetting(string isOpenGateWay, string baseUrl, string environmentName);
        public Sys_Configuration GetSysConfigurationByModuleName(string moduleName);
    }
}
