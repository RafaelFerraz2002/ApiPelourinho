using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using PelourinhoPOS.Authorization.Roles;
using PelourinhoPOS.Authorization.Users;
using PelourinhoPOS.MultiTenancy;

namespace PelourinhoPOS.EntityFrameworkCore
{
    public class PelourinhoPOSDbContext : AbpZeroDbContext<Tenant, Role, User, PelourinhoPOSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public PelourinhoPOSDbContext(DbContextOptions<PelourinhoPOSDbContext> options)
            : base(options)
        {
        }
    }
}
