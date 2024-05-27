using MediatR;

namespace ECommerceApp.Application.Features.Commands.ProductCommands.CreateProduct
{
    public sealed class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
