using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.ApplicationCore
{
    public class BaseDBContext : DbContext
    {
        public BaseDBContext(DbContextOptions<BaseDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           // optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Features>(eb =>
               {
                   eb.HasNoKey();
                   eb.Property(v => v.features).HasColumnName("特征");
               });
            base.OnModelCreating(modelBuilder);
        }


        #region /******************************************用户相关相关************************************************/
        public DbSet<Flow_Users> Users { get; set; } 
        #endregion

    }

    public class Features
    {
        [Column("特征")]
        public string features { get; set; }
    }
}
