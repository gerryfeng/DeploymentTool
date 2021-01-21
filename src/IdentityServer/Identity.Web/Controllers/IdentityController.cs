using Identity.ApplicationCore;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Identity.Web.Controllers
{
    /// <summary>
    /// 登录中心
    /// </summary>
    [ApiController]
    [Route("[action]")]
    public class IdentityController : ControllerBase
    {

        private IOptions<AppSetting> _appConfiguration;
        private IFlowUserService _flowUserService;

        public IdentityController(IOptions<AppSetting> appConfiguration, IFlowUserService flowUserService)
        {
            _appConfiguration = appConfiguration;
            _flowUserService = flowUserService;
        }


        /// <summary>
        /// IdentityService4授权
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="password">密码</param>
        /// <param name="type">类型</param>
        /// <remarks>
        /// 类型(均为SHA1加密后值)：
        ///     dingding(钉钉)/wexin(微信)/phone(手机号)/password(账号密码)
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<ResponseBase<TokenModel>> AuthorizationToken([Required] string loginName, string password, [Required] string type)
        {
            ResponseBase<TokenModel> result = new ResponseBase<TokenModel>();

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
                result.SetError("获取token失败:" + tokenResponse.ErrorDescription);
                return result;
            }

            Flow_Users user;
            string[] name = loginName.Split(',');
            if (type != "password")
                user = _flowUserService.GetUserByTypeId(loginName, type);
            else if (name.Length == 1 || name[1] != "admin" && name[1] != "super")
                user = _flowUserService.GetUser(name[0], password);
            else
                user = new Flow_Users();

            result.data = JsonConvert.DeserializeObject<TokenModel>(tokenResponse.Raw);
            result.data.user_token = user.TOKEN ?? "";
            return result;

        }
    }
}
