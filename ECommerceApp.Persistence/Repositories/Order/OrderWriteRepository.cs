using ECommerceApp.Application.Repositories;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Persistence.Contexts;

namespace ECommerceApp.Persistence.Repositories
{
    public sealed class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
