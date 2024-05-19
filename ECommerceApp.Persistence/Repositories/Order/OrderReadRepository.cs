using ECommerceApp.Application.Repositories;
using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Persistence.Repositories
{
    public sealed class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
    }
}
