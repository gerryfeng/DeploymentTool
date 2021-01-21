using Microsoft.EntityFrameworkCore;
using OMS.ApplicationCore;
using System;

namespace OMS.Infrastructure
{
    public class BaseDBContext : DbContext
    {
        public BaseDBContext(DbContextOptions<BaseDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region 用户相关
            modelBuilder.Entity<Flow_User_Role>(e =>
            {
                e.HasKey(t => new { t.机构ID, t.用户ID });
                e.HasOne(t => t.User).WithMany(t => t.UserRoles).HasForeignKey(t => t.用户ID);
                e.HasOne(t => t.Group).WithMany(t => t.UserRoles).HasForeignKey(t => t.机构ID);
            });

            modelBuilder.Entity<SysUserLogin>().Property(b => b.LoginTime).HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<Flow_Groups>(entity =>
            {
                entity.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Group)
                    .HasForeignKey(e => e.机构ID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            #endregion

            #region 菜单相关
            modelBuilder.Entity<SysMenu>(entity =>
            {
                
                entity.Property(e => e.Nodeid)
                    .ValueGeneratedNever();
                entity.HasMany(e => e.Syspurviews)
                    .WithOne(e => e.SysMenu)
                    .HasForeignKey(e => e.Resid)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SysPurview>(entity =>
            {
                entity.HasKey(e => new { e.Resid, e.Rolecode });

                //entity.HasOne(d => d.SysMenu)
                //    .WithMany(p => p.Syspurviews)
                //    .HasForeignKey(d => d.Resid)
                //    .OnDelete(DeleteBehavior.Cascade);
                // .HasConstraintName("FK_SYSPURVIEW_SYSMENUTREE");

                entity.HasOne(d => d.Flow_Group)
                    .WithMany(p => p.SysPurviews)
                    .HasPrincipalKey(p => p.编码)
                    .HasForeignKey(d => d.Rolecode)
                    .OnDelete(DeleteBehavior.Cascade);
                   // .HasConstraintName("FK_SYSPURVIEW_FLOW_GROUPS");

            });
            #endregion
        }

        #region /******************************************用户相关************************************************/
        public DbSet<Flow_Users> Users { get; set; } 

        public DbSet<Flow_Groups> Groups { get; set; }

        public DbSet<Flow_User_Role> Roles { get; set; }

        public DbSet<SysUserLogin> SysUserLogin { get; set; }
        #endregion

        #region /******************************************菜单相关************************************************/
        public DbSet<SysMenu> Menus { get; set; }

        public DbSet<SysPurview> SysPurviews { get; set; }

        public DbSet<SysPurViewType> SysPurViewTypes { get; set; }
        #endregion


        #region /******************************************配置相关************************************************/
        public DbSet<Sys_Configuration> Sys_Configurations { get; set; }

        public DbSet<Sys_Product> Sys_Products { get; set; }

        public DbSet<Sys_Map_ResetRangeConfig> Sys_Map_ResetRangeConfigs { get; set; }
        #endregion

    }  
}
