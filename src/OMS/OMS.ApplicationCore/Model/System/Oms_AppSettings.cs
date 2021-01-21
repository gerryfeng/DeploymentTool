using System;
using System.Collections.Generic;
using System.Text;

namespace OMS.ApplicationCore
{
    public class Oms_AppSettings
    {
        public AppSetting AppSetting { get; set; }


    }

    public class AppSetting
    {
        public string IdentityServerUrl { get; set; }
    }
}
