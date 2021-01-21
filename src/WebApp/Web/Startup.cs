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
            //��ȡ������������ݿ����ñ��
            var builder = new ConfigurationBuilder();
            builder.AddXmlFile(Path.Combine(ConfigBridge.ConfCenterPath) + @"\app.xml", false, true);
            builder.AddXmlFile(Path.Combine(ConfigBridge.ConfCenterPath, string.IsNullOrEmpty(ConfigBridge.appconfiguration.solutionname)
                ? "��è�ǻ�ˮ��ƽ̨" : ConfigBridge.appconfiguration.solutionname) + @"\ConnectionString.xml", false, true);
            var configurationRoot = builder.Build();

            //ִ�б���ص�����
            ChangeToken.OnChange(() => configurationRoot.GetReloadToken(), () =>
            {
                ConfigBridge = GetConfig();
            });
           
            //���ͨ��DBContext������
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

            //���� https://www.cnblogs.com/VAllen/p/dotnet-core-3-cors-fetch-response-307-temporary-redirect.html
            //����
            services.AddCors(options =>
            {
                options.AddPolicy(Cors, set => {
                    //�����κ���Դ����������
                    //TODO: �µ� CORS �м���Ѿ���ֹ�������� Origin�������� AllowAnyOrigin Ҳ������Ч
                    //AllowAnyOrigin()
                    //����������ʵ���
                    //TODO: Ŀǰ.NET Core 3.1 �� bug, ��ʱͨ�� SetIsOriginAllowed ���
                    //.WithOrigins(Configuration["CorsConfig:Origin"])
                    /* set.SetIsOriginAllowed(origin => true)*/
                    set.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod() ; 
                });
            });

            //ͨ�����ü������ļ��ϴ��Ĵ�С����
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
            //UseCorsҪ��UseRouting֮��UseEndpoints �� UseHttpsRedirection ֮ǰ
            app.UseCors(Cors);

            //����Nlog��nlog.config�����ļ�
            LogManager.LoadConfiguration("Config/nlog.config");
            //���NLog
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
                //���ò�����content-type
                ServeUnknownFileTypes = true
            });
        }
    }
}
