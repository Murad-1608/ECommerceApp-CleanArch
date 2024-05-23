using ECommerceApp.Application.Repositories;
using ECommerceApp.Application.RequestParameters;
using MediatR;

namespace ECommerceApp.Application.Features.Queries.GetAllProduct
{
    public sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _productReadRepository.GetAll(false).Skip(request.Pagination.Page * request.Pagination.Size).Take(request.Pagination.Size);

            return new GetAllProductQueryResponse() { Products = values.ToList() };
        }
    }
}
