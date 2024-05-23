using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Features.Queries.GetAllProduct
{
    public sealed class GetAllProductQueryResponse
    {
        public List<Product> Products { get; set; }
    }
}
