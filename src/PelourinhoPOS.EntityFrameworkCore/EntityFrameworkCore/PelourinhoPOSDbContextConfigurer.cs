using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace PelourinhoPOS.EntityFrameworkCore
{
    public static class PelourinhoPOSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PelourinhoPOSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PelourinhoPOSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
