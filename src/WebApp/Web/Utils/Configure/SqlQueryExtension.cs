using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Web.Services.Configure
{
    public static class SqlQueryExtension
    {
        public static async Task<List<T>> SqlQuery<T>(this DbContext db, string sql, params object[] parameters) where T : class
        {
            using (var db2 = new ContextForQueryType<T>(db.Database.GetDbConnection()))
            {
                return await db2.Set<T>().FromSqlRaw(sql, parameters).ToListAsync();
            }
        }

        private class ContextForQueryType<T> : DbContext where T : class
        {
            private readonly DbConnection connection;

            public ContextForQueryType(DbConnection connection)
            {
                this.connection = connection;
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(connection, options => options.EnableRetryOnFailure());
                base.OnConfiguring(optionsBuilder);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<T>(p =>
                {
                    p.HasNoKey();
                });
                base.OnModelCreating(modelBuilder);
            }
        }
    }
}
