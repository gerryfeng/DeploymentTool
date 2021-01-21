using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO.IOTTools;
using Web.Models.IOTPlatform.IOTTools;
using Web.Utils.IOTTools;

namespace Web.Repository.IOTTolls
{
    public class IOTToolsRepository : DbContext
    {
        public string ConnectionStr;

        public IOTToolsRepository(string _ConnectionStr)
        {
            ConnectionStr = _ConnectionStr;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<HistoryCountReslut>(eb =>
                {
                    eb.HasNoKey();
                    eb.Property(v => v.CountNumber).HasColumnName("总数");
                    eb.Property(v => v.startTime).HasColumnName("起始时间");
                    eb.Property(v => v.endTime).HasColumnName("结束时间");
                });
            modelBuilder
                .Entity<AddressEnress>(eb =>
                {
                    eb.HasNoKey();
                    eb.Property(v => v.Name).HasColumnName("名称");
                });
        }


        public DbSet<DbIotEquipType> dbIotEquipTypes { get; set; }

        public DbSet<DbIotScation> dbIotScations { get; set; }

        public DbSet<AddressEnress> dbAddressName { get; set; }

        public DbSet<HistoryCountReslut> countResluts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionStr);

        }



    }
}
