using ECommerceApp.Application.Repositories;
using ECommerceApp.Domain.Entities;
using MediatR;

namespace ECommerceApp.Application.Features.Commands.CreateProduct
{
    public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            await _productWriteRepository.AddAsync(new Product()
            {
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price
            });
            await _productWriteRepository.SaveAsync();

            return new CreateProductCommandResponse();
        }
    }
}
