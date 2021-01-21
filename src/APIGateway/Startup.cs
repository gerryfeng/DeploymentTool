using Exceptionless;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.IO;

namespace APIGateway
{
    public class Startup
    {
        private IWebHostEnvironment CurrentEnvironment { get; }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            CurrentEnvironment = environment;
            Configuration = configuration;
            initSqliteDb();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var confCenterPath = new ConfigBridge.ConfigBridge(CurrentEnvironment.IsDevelopment()).ConfCenterPath;

            var builder = new ConfigurationBuilder()
                       .SetBasePath(CurrentEnvironment.ContentRootPath)
                       .AddJsonFile("appsettings.json", true, true)
                       .AddJsonFile($"appsettings.{CurrentEnvironment.EnvironmentName}.json", true, true)
                       
                       .AddEnvironmentVariables();

            // 生产环境加载 ConfCenter 目录下的配置文件
            if (!CurrentEnvironment.IsDevelopment())
            {
                builder.AddJsonFile($@"{confCenterPath}\NetCoreConfigs\OMS\appsettings.json", false, true);
                builder.AddJsonFile($@"{confCenterPath}\NetCoreConfigs\GateWay\ocelot.json", false, true);
            }
            else
                builder.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

            var Configuration = builder.Build();


            string identityServerUrl = ((ConfigurationSection)Configuration.GetSection("AppSetting:IdentityServerUrl")).Value;
            services.AddOcelot(Configuration);

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("CityInterface",m => {
                    m.Authority = $"{identityServerUrl}";
                    m.ApiName = CityServerClient.InterfaceApiName;
                    m.ApiSecret = CityServerClient.InterfaceSecret;
                    m.RequireHttpsMetadata = false;
                    m.SupportedTokens = SupportedTokens.Both;
                })
                .AddIdentityServerAuthentication("CityServer", m =>
                {
                    m.Authority = $"{identityServerUrl}";
                    m.ApiName = CityServerClient.ApiName;
                    m.ApiSecret = CityServerClient.InterfaceSecret;
                    m.RequireHttpsMetadata = false;
                    m.SupportedTokens = SupportedTokens.Both;
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
            services.Configure<ForwardedHeadersOptions>(options => {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });
           
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseForwardedHeaders();
            //app.UseExceptionless("zygazhd1ngiuUdh21eIt0WY8s7jqWbYJzDmBTaxQ");
            app.UseLogWare();
            //app.UseDownstreamContextMiddleware();
            app.UseOcelot().Wait();
        }



        private  void initSqliteDb()
        {
            if (CurrentEnvironment.IsDevelopment())
            {
                SqliteHelper.ConnectionString = $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\..\ConfCenter\Log.db")}";
            }
            else
            {
                SqliteHelper.ConnectionString = $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\ConfCenter\Log.db")}";
            }

            string sql =
                        @"CREATE TABLE IF NOT EXISTS 
                             CallLog (
                                  Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                  UserIp TEXT,
                                  DownstreamRequest TEXT,
                                  Path TEXT,
                                  Method TEXT,
                                  QueryString TEXT,
                                  RequestBodyLength integer,
                                  CallTime TEXT,
                                  Result integer,
                                  ConsumerTime integer DEFAULT '',
                                  ResponseSize integer,
                                  ErrorMsg TEXT
                             )";
            SqliteHelper.ExecuteNonQuery(sql);
        }
    }
}
