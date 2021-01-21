using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using Web.DTO;
using Web.DTO.Configure;
using Web.Models.Configure;
using Web.Models.Configure.Entity;
using Web.Models.IOTPlatform.Configure.Entity;
using Web.Models.ThreeConfigure;

namespace Web.Repository
{
    public class BaseDBContext : DbContext
    {

        [Obsolete]
        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        public BaseDBContext(DbContextOptions<BaseDBContext> options) : base(options)
        {
          
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Features>(eb =>
               {
                   eb.HasNoKey();
                   eb.Property(v => v.features).HasColumnName("特征");
               });

            //modelBuilder.Entity<ThreeSketch>().HasKey("ID");

            base.OnModelCreating(modelBuilder);
        }

        /******************************************模型相关************************************************/
        public DbSet<ModelType> modelTypes { get; set; }

        public DbSet<Model> models { get; set; }

        public DbSet<ModelImage> modelImages { get; set; }

        public DbSet<ExportModel> exportModels { get; set; }


        /******************************************画板相关************************************************/
        //画板保存实体
        public DbSet<Sketchpad> sketchpads { get; set; }

        //画板查询返回
        public DbSet<QuerySketch> querySketches { get; set; }

        public DbSet<SketchPadImage> sketchPadImages { get; set; }


        public DbSet<SketchPadJson> sketchPadJsons { get; set; }

        public DbSet<ExportSkpad> exportSkpads { get; set; }

        public DbSet<ModelInformation> modelInformation { get; set; }

        public DbSet<ModelAttribute> attributes { get; set; }

        public DbSet<ModelQueryDTO> modelQueryDTOs { get; set; }

        public DbSet<PointAddress> pointAddresses { get; set; }

        public DbSet<PointAddressEntry> pointAddressesEntry { get; set; }

        public DbSet<SketchPadType> sketchPadTypes { get; set; }

        public DbSet<DeviceType> deviceTypes { get; set; }




        /******************************************三维相关************************************************/
        public DbSet<Features> features { get; set; }

        public DbSet<ModelFeatureData> modelFeatureDatas { get; set; }

        public DbSet<ThreeSketch> threeSkeths { get; set; }

        public DbSet<ThreeModelGroup> threeModelGroups { get; set; }

        public DbSet<ThreeModel> threeModel { get; set; }

    }
}
