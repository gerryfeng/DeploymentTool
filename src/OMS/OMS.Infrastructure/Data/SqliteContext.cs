using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OMS.ApplicationCore;

namespace OMS.Infrastructure
{
    /// <summary>
    /// Sqlite 服务调用频次日志
    /// 文件位置：ConfCenter/Log.DB
    /// </summary>
    public class SqliteContext : DbContext
    {
        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite("Data Source=d:/mydb.db");
            //var log = new LoggerFactory();
            //log.AddProvider(new EFLoggerProvider());
            //optionsBuilder.EnableSensitiveDataLogging(true);
            //optionsBuilder.UseLoggerFactory(log);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<CallLog> CallLog { get; set; }
    }


    public class SqliteOperationContext : DbContext
    {
        public SqliteOperationContext(DbContextOptions<SqliteOperationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<OperationLog> OperationLog { get; set; }
    }
}
