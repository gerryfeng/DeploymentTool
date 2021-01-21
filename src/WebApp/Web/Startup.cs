using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Extensions.Logging;
using Web.DayModule;
using Web.Models;
using Web.Repository;
using Web.Utils;

namespace Web
{
    public class Startup
    {
        private readonly string Cors = "AllowSpecificOrigins";

        private  IWebHostEnvironment CurrentEnvironment { get; }

        private  ConfigBridge.ConfigBridge ConfigBridge { get; set; }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            CurrentEnvironment = environment;
            Configuration = configuration;
            ConfigBridge = GetConfig();
        }



        public void ConfigureServices(IServiceCollection services)
        {
            //读取解决方案和数据库配置变更
            var builder = new ConfigurationBuilder();
            builder.AddXmlFile(Path.Combine(ConfigBridge.ConfCenterPath) + @"\app.xml", false, true);
            builder.AddXmlFile(Path.Combine(ConfigBridge.ConfCenterPath, string.IsNullOrEmpty(ConfigBridge.appconfiguration.solutionname)
                ? "熊猫智慧水务平台" : ConfigBridge.appconfiguration.solutionname) + @"\ConnectionString.xml", false, true);
            var configurationRoot = builder.Build();

            //执行变更回调函数
            ChangeToken.OnChange(() => configurationRoot.GetReloadToken(), () =>
            {
                ConfigBridge = GetConfig();
            });
           
            //添加通用DBContext上下文
            services.AddDbContext<BaseDBContext>(options => options.UseSqlServer(ConfigBridge.connConfig.workflow.Value.ToString()));

            //services.AddAutoMapper(typeof(DayProfile));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IDayService, DayService>();


            services.AddControllers
                (
                    options => options.Filters.Add(new ExceptionFilter.CustomerExceptionFilter())
                )
                .AddJsonOptions(configure => {
                    configure.JsonSerializerOptions.Converters.Add(new DatetimeJsonConverter());
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Panda API", Version = "v1" });
                c.IncludeXmlComments(System.IO.Path.Combine(System.AppContext.BaseDirectory, "Web.xml"), true);
            });

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(OAuthConfig.ApiResources)
                .AddInMemoryApiScopes(OAuthConfig.ApiScopes)
                .AddInMemoryClients(OAuthConfig.Clients)
                .AddTestUsers(OAuthConfig.TestUsers);

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "pdApi";
                });

            //跨域 https://www.cnblogs.com/VAllen/p/dotnet-core-3-cors-fetch-response-307-temporary-redirect.html
            //跨域
            services.AddCors(options =>
            {
                options.AddPolicy(Cors, set => {
                    //允许任何来源的主机访问
                    //TODO: 新的 CORS 中间件已经阻止允许任意 Origin，即设置 AllowAnyOrigin 也不会生效
                    //AllowAnyOrigin()
                    //设置允许访问的域
                    //TODO: 目前.NET Core 3.1 有 bug, 暂时通过 SetIsOriginAllowed 解决
                    //.WithOrigins(Configuration["CorsConfig:Origin"])
                    /* set.SetIsOriginAllowed(origin => true)*/
                    set.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod() ; 
                });
            });

            //通过设置即重置文件上传的大小限制
            services.Configure<FormOptions>(o =>  
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = long.MaxValue;
                o.MultipartBoundaryLengthLimit = int.MaxValue;
                o.MultipartHeadersCountLimit = int.MaxValue;
                o.MultipartHeadersLengthLimit = int.MaxValue;
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(x => x.Name.EndsWith("service", StringComparison.OrdinalIgnoreCase))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => t.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase))
                .AsImplementedInterfaces();
        }

        public ConfigBridge.ConfigBridge GetConfig() {
            ConfigBridge = new ConfigBridge.ConfigBridge(CurrentEnvironment.IsDevelopment());

            ConfigBridge.DeserializeConnConfig();
            return ConfigBridge;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactor)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                if (env.IsDevelopment())
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Panda API V1");
                }
                else
                {
                    c.SwaggerEndpoint("/Publish/Web/swagger/v1/swagger.json", "Panda API V1");
                }
            });
            app.UseRouting();
            //UseCors要在UseRouting之后，UseEndpoints 和 UseHttpsRedirection 之前
            app.UseCors(Cors);

            //加载Nlog的nlog.config配置文件
            LogManager.LoadConfiguration("Config/nlog.config");
            //添加NLog
            loggerFactor.AddNLog();

            app.UseResponseCaching();
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                //设置不限制content-type
                ServeUnknownFileTypes = true
            });
        }
    }
}
