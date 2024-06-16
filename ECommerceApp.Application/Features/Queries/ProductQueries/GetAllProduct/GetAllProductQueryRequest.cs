using ECommerceApp.Application.RequestParameters;
using MediatR;

namespace ECommerceApp.Application.Features.Queries.ProductQueries.GetAllProduct
{
    public sealed class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
    {
    }
}
