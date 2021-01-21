using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigBridge
{
    /// <summary>
    /// 返回信息基类
    /// </summary>
    public class BaseResult
    {
        /// <summary>
        /// 指示服务是否正常执行
        /// </summary>
        public bool success { get; set; } = false;

        /// <summary>
        /// 服务异常信息来源。服务报错：Service，GIS服务器报错：GISServer
        /// </summary>
        public ErrorSource source { get; set; } = ErrorSource.Service;

        /// <summary>
        /// 服务异常信息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 服务异常信息扩展
        /// </summary>
        public string messageEx { get; set; }
    }

    /// <summary>
    /// 错误信息来源的枚举类
    /// </summary>
    public enum ErrorSource
    {
        /// <summary>
        /// 服务报错
        /// </summary>
        Service = 0,

        /// <summary>
        /// GIS服务器报错
        /// </summary>
        GISServer = 1,

        /// <summary>
        /// 其它来源
        /// </summary>
        Other = 99
    }


    /// <summary>
    /// 运维系统配置文件类
    /// </summary>
    public class OMSLoginConfig
    {
        /// <summary>
        /// 登录方式0-不需要登录 1-需要登录
        /// </summary>
        public string loginMode { get; set; } = "0";

        /// <summary>
        /// 用户模式为管理员时的登录名
        /// </summary>
        public string loginName { get; set; } = "admin";

        /// <summary>
        /// 用户模式为管理员时的密码
        /// </summary>
        public string password { get; set; } = "admin";

        /// <summary>
        /// 帮助模式 false-关闭 true-打开
        /// </summary>
        public bool helpMode { get; set; } = false;
        public string superPassword { get; set; }
    }
}
