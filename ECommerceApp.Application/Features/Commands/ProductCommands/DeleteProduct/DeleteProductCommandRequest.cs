using MediatR;

namespace ECommerceApp.Application.Features.Commands.ProductCommands.DeleteProduct
{
    public sealed class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public string Id { get; set; }
    }
}
