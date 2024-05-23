using ECommerceApp.Application.RequestParameters;
using MediatR;

namespace ECommerceApp.Application.Features.Queries.GetAllProduct
{
    public sealed class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
    {
        public Pagination Pagination { get; set; }
    }
}
