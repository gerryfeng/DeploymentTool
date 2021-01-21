using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace OMS.Web
{
    public class SwaggerTagDescriptions : IDocumentFilter
    {

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new List<OpenApiTag>
            {
                new OpenApiTag{ Name="Login",Description="登录中心"},
                new OpenApiTag{ Name="DBManager",Description="数据库管理"},
                new OpenApiTag{ Name="UserCenter",Description="用户中心"},
                new OpenApiTag{ Name="PlatformCenter",Description="平台中心"},
                new OpenApiTag{ Name="FileCenter",Description="文件中心"},
                new OpenApiTag{ Name="LogCenter", Description="日志中心"},
                new OpenApiTag{ Name = "ConfigCenter", Description ="配置中心"}
            };
        }
    }
}
