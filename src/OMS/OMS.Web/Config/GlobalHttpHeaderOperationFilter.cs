using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace OMS.Web
{
    public class GlobalHttpHeaderOperationFilter : IOperationFilter
    {
        private IConfiguration _configuration;
        private IOptions<AppSetting> _appConfiguration;

        public GlobalHttpHeaderOperationFilter(IConfiguration configuration, IOptions<AppSetting> appConfiguration)
        {
            _configuration = configuration;
            _appConfiguration = appConfiguration;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var identityServer = _appConfiguration.Value.IdentityServerUrl;//((ConfigurationSection)_configuration.GetSection("IdentityServerUrl")).Value;
            //如果是Identity认证方式，不需要界面添加x-token得输入框
            if (!string.IsNullOrWhiteSpace(identityServer))
                return;

            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            var actionAttrs = context.ApiDescription.ActionDescriptor.EndpointMetadata;
            var isAnony = actionAttrs.Any(a => a.GetType() == typeof(AllowAnonymousAttribute));

            //不是匿名，则添加默认的X-Token
            if (!isAnony)
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Token",
                    In = ParameterLocation.Header,
                    Description = "当前登录用户登录token",
                    Required = false
                });
            }
        }
    }

    /// <summary>
    /// swagger请求的时候，如果是Identity方式，自动加授权方式
    /// </summary>
    //public class AuthResponsesOperationFilter : IOperationFilter
    //{
    //    private IConfiguration _configuration;

    //    public AuthResponsesOperationFilter(IConfiguration configuration)
    //    {
    //        _configuration = configuration;
    //    }

    //    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    //    {
    //        var identityServer = ((ConfigurationSection)_configuration.GetSection("IdentityServerUrl")).Value;
    //        if (!string.IsNullOrWhiteSpace(identityServer))
    //        {
    //            return;
    //        }

    //        var anonymous = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
    //            .Union(context.MethodInfo.GetCustomAttributes(true))
    //            .OfType<AllowAnonymousAttribute>().Any();
    //        if (!anonymous)
    //        {
    //            var security = new List<OpenApiSecurityRequirement>();
    //            security.Add(new OpenApiSecurityRequirement {
    //                {
    //                    new OpenApiSecurityScheme
    //                    {
    //                        Reference = new OpenApiReference
    //                        {
    //                            Type = ReferenceType.SecurityScheme,
    //                            Id = "oauth2"
    //                        }
    //                    },
    //                    new[] { "openauthapi" }
    //                }
    //            });
    //            operation.Security = security;               
    //        }
    //    }
    //}
}
