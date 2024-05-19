using ECommerceApp.Application.Repositories;
using ECommerceApp.Domain.Entities.Common;
using ECommerceApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerceApp.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext appDbContext;
        public WriteRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public DbSet<T> Table => appDbContext.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry entry = await Table.AddAsync(model);
            return entry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool RemoveRange(List<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }
        public async Task<bool> RemoveAsync(string id)
        {
            var value = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

            return Remove(value);
        }
        public bool Remove(T model)
        {
            EntityEntry entry = Table.Remove(model);
            return entry.State == EntityState.Deleted;
        }
        public bool Update(T model)
        {
            EntityEntry entity = Table.Update(model);
            return entity.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync() => await appDbContext.SaveChangesAsync();


    }
}
