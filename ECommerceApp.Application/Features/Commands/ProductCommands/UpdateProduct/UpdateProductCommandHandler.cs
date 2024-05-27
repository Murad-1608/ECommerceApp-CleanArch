using ECommerceApp.Application.Repositories;
using ECommerceApp.Domain.Entities;
using MediatR;

namespace ECommerceApp.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Id = Guid.Parse(request.Id),
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock

            };
            _productWriteRepository.Update(product);
            await _productWriteRepository.SaveAsync();
            return new UpdateProductCommandResponse();

        }
    }
}
