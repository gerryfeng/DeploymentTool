using AutoMapper;
using IdentityModel.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OMS.ApplicationCore;
using OMS.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;

namespace OMS.Web
{
    /// <summary>
    /// 登录中心
    /// </summary>
    [ApiController]
    [Route("[action]")]
    public class LoginController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<LoginController> _logger;
        private IOptions<AppSetting> _appConfiguration;
        private IFlowUserService _userService;
        private readonly IWebHostEnvironment _environment;
        private readonly SysUserLoginService _userLoginService;

        public LoginController(IOptions<AppSetting> appConfiguration, IMapper mapper, ILogger<LoginController> logger, IFlowUserService userService, IWebHostEnvironment environment, SysUserLoginService userLoginService)
        {
            _appConfiguration = appConfiguration;
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
            _environment = environment;
            _userLoginService = userLoginService;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="systemType">系统类型</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CheckUserResult> OMSLogin(
            [FromForm, Required]string userName, 
            [FromForm, Required]string password,[FromForm] string systemType)
        {
            CheckUserResult checkResult = new CheckUserResult();
            ConfigBridge.ConfigBridge config = new ConfigBridge.ConfigBridge(_environment.IsDevelopment());
            checkResult = await _userService.OMSLoginAsync(userName, password, config.LoginConfig.superPassword, config.LoginConfig.loginName, config.LoginConfig.password, ConfigBridge.ConfigBridge.OMSRole);

            if (!checkResult.pass)
            {
                throw new Exception("用户名或密码错误！");
            }                  
            checkResult.token = await AuthorizationTokenAysnc(userName + ","+ checkResult.userMode, EncryptHelper.SHA1_Encrypt(password), "password");
            await _userLoginService.SaveAsync(new SysUserLogin()
            {
                IP = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                SystemType = systemType,
                LoginName = userName,
                ShowName = userName,
                LoginTime = DateTime.Now
            }) ;                
            return checkResult;
        }



        /// <summary>
        /// IdentityService4授权
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="password">密码</param>
        /// <param name="type">类型</param>
        /// <remarks>
        /// 类型：
        ///     dingding(钉钉)/wexin(微信)/phone(手机号)/paseword(账号密码)
        /// </remarks>
        /// <returns></returns>
        private async Task<TokenModel> AuthorizationTokenAysnc([Required] string loginName, string password, [Required] string type)
        {
            TokenResponse tokenResponse = await new HttpClient().RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = _appConfiguration.Value.IdentityServerUrl + "/connect/token",
                ClientId = _appConfiguration.Value.ClientId,
                ClientSecret = _appConfiguration.Value.Secret,
                Scope = _appConfiguration.Value.ApiScops,  
                UserName = loginName,
                Password = password + "," + type,
            });

            if (tokenResponse.IsError)
            {
                throw new Exception("获取token失败:"+ tokenResponse.ErrorDescription);
            }

            return JsonConvert.DeserializeObject<TokenModel>(tokenResponse.Raw);
        }     
    }
}
