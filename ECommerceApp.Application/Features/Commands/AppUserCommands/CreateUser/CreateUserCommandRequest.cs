using MediatR;

namespace ECommerceApp.Application.Features.Commands.AppUserCommands.CreateUser
{
    public sealed class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
