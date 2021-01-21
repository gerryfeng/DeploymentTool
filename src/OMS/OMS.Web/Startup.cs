using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;
using ConfigBridge;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Extensions.Logging;
using OMS.Infrastructure;

namespace OMS.Web
{
    public class Startup
    {
        private readonly string Cosr = "AllowSpecificOrigins";

        private IWebHostEnvironment CurrentEnvironment { get; }

        private ConfigBridge.ConfigBridge ConfigBridge { get; set; }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            CurrentEnvironment = environment;
            Configuration = configuration;
            ConfigBridge = GetConfig();

            OMSPath.Init(ConfigBridge.ConfCenterPath, ConfigBridge.appconfiguration.solutionname);
            OMSState.RefreshOMSState();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string solutionPath = (string.IsNullOrEmpty(ConfigBridge.appconfiguration.solutionname)
                ? "熊猫智慧水务平台" : ConfigBridge.appconfiguration.solutionname);

            //读取解决方案和数据库配置变更
            var builder = new ConfigurationBuilder()
                .SetBasePath(ConfigBridge.ConfCenterPath)
                .AddXmlFile("app.xml", false, true)
                .AddJsonFile($@"{solutionPath}\OMS\OMSState.txt", false, true)
                .AddJsonFile($@"{solutionPath}\OMS\OMSConfig.txt", false, true)
                .AddXmlFile($@"{solutionPath}\ConnectionString.xml", false, true);

            // 生产环境加载 ConfCenter 目录下的配置文件
            if (!CurrentEnvironment.IsDevelopment())
            {
                builder.AddJsonFile($@"{ConfigBridge.ConfCenterPath}\NetCoreConfigs\OMS\appsettings.json", false, true);
            }

            var ConfigurationProduct = builder.Build();

            //执行变更回调函数
            ChangeToken.OnChange(() => ConfigurationProduct.GetReloadToken(), () =>
            {
                ConfigBridge = GetConfig();
                OMSPath.Init(ConfigBridge.ConfCenterPath, ConfigBridge.appconfiguration.solutionname);
                OMSState.RefreshOMSState();
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers()
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());

                    //Json数据以驼峰命名显示
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
               })
               .AddMvcOptions(options=>options.Filters.Add(typeof(Filters.GlobalActionFilter)))
               .AddMvcOptions(options=>options.Filters.Add(typeof(Filters.GlobalExceptionFilter)));

            //添加Sqlite上下文
            //"Filename="+Path.Combine(configBridge.ConfCenterPath) + @"\Log.DB"
            services.AddDbContext<SqliteContext>(options => {
                if (CurrentEnvironment.IsDevelopment())
                {
                    var log = new LoggerFactory();
                    log.AddProvider(new EFLoggerProvider());
                    options.EnableSensitiveDataLogging(true);
                    options.UseLoggerFactory(log);
                }
                options.UseSqlite("Filename=" + Path.Combine(ConfigBridge.ConfCenterPath) + @"\Log.DB");
            });

            services.AddDbContext<SqliteOperationContext>(options => {
                options.UseSqlite("Filename=" + Path.Combine(ConfigBridge.ConfCenterPath) + @"\..\Log\OMS\OMSOperationLog.sqlite");
            });


            //添加通用DBContext上下文
            services.AddDbContext<BaseDBContext>(options => {
                if (CurrentEnvironment.IsDevelopment())
                {
                    var log = new LoggerFactory();
                    log.AddProvider(new EFLoggerProvider());
                    options.EnableSensitiveDataLogging(true);
                    options.UseLoggerFactory(log);
                }
                options.UseSqlServer(ConfigBridge.connConfig.workflow.Value.ToString());
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddControllers();

            //全局过滤器
            //services.AddControllers(options => options.Filters.Add(typeof(GlobalExceptionFilter)));
           // services.AddControllers(options => options.Filters.Add(typeof(ApiLogFilter)));

            //关闭自动验证 -- 模型验证
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            // services.AddControllers(options => options.Filters.Add(typeof(GlobalActionFilter)));

            string identityServerUrl;
            if (CurrentEnvironment.IsDevelopment())
            {
                //映射配置文件
                services.Configure<AppSetting>(Configuration.GetSection("AppSetting"));
                identityServerUrl = ((ConfigurationSection)Configuration.GetSection("AppSetting:IdentityServerUrl")).Value;
            }
            else
            {
                //映射配置文件
                services.Configure<AppSetting>(ConfigurationProduct.GetSection("AppSetting"));
                identityServerUrl = ((ConfigurationSection)ConfigurationProduct.GetSection("AppSetting:IdentityServerUrl")).Value;
            }
            if (!string.IsNullOrWhiteSpace(identityServerUrl))
            {
                services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = identityServerUrl;
                        options.RequireHttpsMetadata = false;
                        options.Audience = OAuthConfig.OMSClient.ApiName;
                    });
            }

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "React OMS API V1", Version = "v1" });
                c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "OMS.Web.xml"));

                c.OperationFilter<GlobalHttpHeaderOperationFilter>(); //添加httpHeader参数
                c.DocumentFilter<SwaggerTagDescriptions>();

                if (!string.IsNullOrWhiteSpace(identityServerUrl))
                {
                    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Description = "OAuth2登陆授权",
                        Flows = new OpenApiOAuthFlows
                        {
                            Implicit = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri($"{identityServerUrl}/connect/authorize"),
                                TokenUrl = new Uri($"{identityServerUrl}/connect/token"),
                                Scopes = new Dictionary<string, string>
                                {
                                    { OAuthConfig.OMSClient.ApiName, "同意openauth.webapi 的访问权限" }//指定客户端请求的api作用域。 如果为空，则客户端无法访问
                                }
                            }
                        }
                    });
                    c.OperationFilter<AuthResponsesOperationFilter>();
                }
            });

            services.AddCors(options =>
            {
                options.AddPolicy(Cosr, set => {
                    //允许任何来源的主机访问
                    //TODO: 新的 CORS 中间件已经阻止允许任意 Origin，即设置 AllowAnyOrigin 也不会生效
                    //AllowAnyOrigin()
                    //设置允许访问的域
                    //TODO: 目前.NET Core 3.1 有 bug, 暂时通过 SetIsOriginAllowed 解决
                    //.WithOrigins(Configuration["CorsConfig:Origin"])
                    /* set.SetIsOriginAllowed(origin => true)*/
                    set.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            //通过设置即重置文件上传的大小限制
            services.Configure<FormOptions>(o =>
            {
                o.BufferBodyLengthLimit = long.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = long.MaxValue;
                o.MultipartBoundaryLengthLimit = int.MaxValue;
                o.MultipartHeadersCountLimit = int.MaxValue;
                o.MultipartHeadersLengthLimit = int.MaxValue;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                if (env.IsDevelopment())
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "React OMS API V1");
                }
                else
                {
                    c.SwaggerEndpoint("/Publish/OMS/swagger/v1/swagger.json", "React OMS API V1");
                }

                c.OAuthClientId(OAuthConfig.OMSClient.ClientId);
                c.OAuthAppName(OAuthConfig.OMSClient.ApiDisplayName);
            });

            app.UseRouting();
            app.UseCors(Cosr);

            //加载Nlog的nlog.config配置文件
            LogManager.LoadConfiguration("Config/Nlog.config");
            //添加NLog
            loggerFactory.AddNLog();
            app.UseResponseCaching();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                //设置不限制content-type
                ServeUnknownFileTypes = true
            });

            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
        }

        /// <summary>
        /// autofac才有此特性
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            Assembly app = Assembly.Load("OMS.ApplicationCore");
            builder.RegisterAssemblyTypes(app).Where(x => x.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase)).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.Load("OMS.Infrastructure")).Where(x => x.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase)).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(app).Where(x => x.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase)).SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.Load("OMS.Infrastructure")).Where(x => x.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase)).SingleInstance();
        }

        public ConfigBridge.ConfigBridge GetConfig()
        {
            ConfigBridge = new ConfigBridge.ConfigBridge(CurrentEnvironment.IsDevelopment());

            ConfigBridge.DeserializeConnConfig();
            return ConfigBridge;
        }
    }
}
