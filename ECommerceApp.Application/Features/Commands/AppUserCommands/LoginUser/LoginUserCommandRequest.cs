using MediatR;

namespace ECommerceApp.Application.Features.Commands.AppUserCommands.LoginUser
{
    public sealed class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
    }
}
