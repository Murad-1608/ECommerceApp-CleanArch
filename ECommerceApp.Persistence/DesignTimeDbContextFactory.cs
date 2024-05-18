using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ECommerceApp.Persistence.Contexts;

namespace ECommerceApp.Persistence
{
    public sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ECommerceDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
