using ECommerceApp.Application.Repositories;
using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Persistence.Repositories
{
    public sealed class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
    }
}
