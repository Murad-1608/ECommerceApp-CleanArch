using ECommerceApp.Application.Repositories;
using ECommerceApp.Domain.Entities.Common;
using ECommerceApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerceApp.Persistence.Repositories
{
    public sealed class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext appDbContext;
        public ReadRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public DbSet<T> Table => appDbContext.Set<T>();

        public IQueryable<T> GetAll() => Table;

        public Task<T> GetByIdAsync(string id) => Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression) => await Table.FirstOrDefaultAsync(expression);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression) => Table.Where(expression);
    }
}
