using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web.Models
{
    public partial class HolidayContext : DbContext
    {
        public HolidayContext()
        {
        }

        public HolidayContext(DbContextOptions<HolidayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<节假日信息表> 节假日信息表 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=.;Database=dbCore;User ID=sa;Password=sa;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<节假日信息表>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.日期).HasColumnType("date");

                entity.Property(e => e.节假日类型)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<节假日信息表>()
                .HasIndex(d => d.日期)
                .IsUnique();


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
