using Autofac;
using AutoMapper;
using Identity.ApplicationCore;
using Identity.Web;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System;

namespace IdentityServer
{
    public class Startup
    {
        private readonly string Cors = "AllowSpecificOrigins";

        private IWebHostEnvironment Environment { get; }

        private ConfigBridge.ConfigBridge ConfigBridge { get; set; }

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Environment = environment;
            Configuration = configuration;
            ConfigBridge = GetConfig();
        }

        public ConfigBridge.ConfigBridge GetConfig()
        {
            ConfigBridge = new ConfigBridge.ConfigBridge(Environment.IsDevelopment());

            ConfigBridge.DeserializeConnConfig();
            return ConfigBridge;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string solutionPath = (string.IsNullOrEmpty(ConfigBridge.appconfiguration.solutionname)
                ? "熊猫智慧水务平台" : ConfigBridge.appconfiguration.solutionname);

            string confCenterPath = ConfigBridge.ConfCenterPath;

            //读取解决方案和数据库配置变更
            var builder = new ConfigurationBuilder()
                .SetBasePath(ConfigBridge.ConfCenterPath)
                .AddXmlFile("app.xml", false, true)
                .AddXmlFile($@"{solutionPath}\ConnectionString.xml", false, true);

            // 生产环境加载 ConfCenter 目录下的配置文件
            if (!Environment.IsDevelopment())
            {
                builder.AddJsonFile($@"{confCenterPath}\NetCoreConfigs\Identity\identity.json", false, true);
                builder.AddJsonFile($@"{confCenterPath}\NetCoreConfigs\OMS\appsettings.json", false, true);
            }
            
            var configurationProduct = builder.Build();

            //执行变更回调函数
            ChangeToken.OnChange(() => configurationProduct.GetReloadToken(), () =>
            {
                ConfigBridge = GetConfig();
            });

            //添加通用DBContext上下文
            services.AddDbContext<BaseDBContext>(options => options.UseSqlServer(ConfigBridge.connConfig.workflow.Value.ToString()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllersWithViews();

            var identityServerBuilder = services.AddIdentityServer();

            identityServerBuilder
                .AddDeveloperSigningCredential()
                .AddProfileService<ProfileService>()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();

            if (Environment.IsDevelopment())
            {
                identityServerBuilder.AddInMemoryIdentityResources(Configuration.GetSection("IdentityServer:IdentityResources"));
                identityServerBuilder.AddInMemoryApiResources(Configuration.GetSection("IdentityServer:ApiResources"));
                identityServerBuilder.AddInMemoryApiScopes(Configuration.GetSection("IdentityServer:ApiScopes"));
                identityServerBuilder.AddInMemoryClients(Configuration.GetSection("IdentityServer:Clients"));
                services.Configure<AppSetting>(Configuration.GetSection("AppSetting"));
            }
            else
            {
                identityServerBuilder.AddInMemoryIdentityResources(configurationProduct.GetSection("IdentityServer:IdentityResources"));
                identityServerBuilder.AddInMemoryApiResources(configurationProduct.GetSection("IdentityServer:ApiResources"));
                identityServerBuilder.AddInMemoryApiScopes(configurationProduct.GetSection("IdentityServer:ApiScopes"));
                identityServerBuilder.AddInMemoryClients(configurationProduct.GetSection("IdentityServer:Clients"));

                services.Configure<AppSetting>(configurationProduct.GetSection("AppSetting"));
            }

            services.AddAuthentication()
                .AddGoogle("Google", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    options.ClientId = "<insert here>";
                    options.ClientSecret = "<insert here>";
                })
                .AddOpenIdConnect("oidc", "Demo IdentityServer", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.SignOutScheme = IdentityServerConstants.SignoutScheme;
                    options.SaveTokens = true;

                    options.Authority = "https://demo.identityserver.io/";
                    options.ClientId = "interactive.confidential";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };
                });

            // 由于 samesite 添加
            services.ConfigureNonBreakingSameSiteCookies();
        }

        /// <summary>
        /// autofac才有此特性
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Flow_Users).Assembly)
                .Where(x => x.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase)).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(Flow_Users).Assembly)
                .Where(x => x.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase)).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(Flow_Users).Assembly)
                .Where(x => x.Name.EndsWith("Validator", StringComparison.OrdinalIgnoreCase)).AsImplementedInterfaces();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // Add this before any other middleware that might write cookies
            app.UseCookiePolicy();

            // This will write cookies, so make sure it's after the cookie policy
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
        }
    }
}
