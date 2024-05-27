using ECommerceApp.Application.RequestParameters;
using MediatR;

namespace ECommerceApp.Application.Features.Queries.ProductQueries.GetAllProduct
{
    public sealed class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
