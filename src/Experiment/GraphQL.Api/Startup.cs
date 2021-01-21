using GraphQL.Api.Repositories;
using GraphQL.Api.Schemas;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("SqlServerConn"));
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader();
                });
            });

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddScoped<IDataStore, DataStore>();
            services.AddScoped<ISchema, InventorySchema>();
            services.AddScoped<InventoryQuery>();
            services.AddScoped<InventoryMutation>();

            services.AddScoped<ItemType>();
            services.AddScoped<ItemInputType>();
            services.AddScoped<CustomerType>();
            services.AddScoped<CustomerInputType>();
            services.AddScoped<OrderType>();
            services.AddScoped<OrderInputType>();
            services.AddScoped<OrderItemType>();
            services.AddScoped<OrderItemInputType>();

            services.AddScoped<IDependencyResolver>(s =>
                new FuncDependencyResolver(s.GetRequiredService));

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            })
            .AddWebSockets()
            .AddDataLoader();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();

            //app.UseStaticFiles();

            app.UseCors(MyAllowSpecificOrigins);

            //app.UseMiddleware<GraphQLMiddleware>();

            // this is required for websockets support
            //app.UseWebSockets();

            // use websocket middleware for InventorySchema at path /graphql
            //app.UseGraphQLWebSockets<ISchema>("/graphql");

            // use HTTP middleware for InventorySchema at path /graphql
            app.UseGraphQL<ISchema>("/graphql");

            // use graphql-playground middleware at default url /ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
