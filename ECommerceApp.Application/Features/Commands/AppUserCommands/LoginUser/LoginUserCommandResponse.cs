using ECommerceApp.Application.DTOs;

namespace ECommerceApp.Application.Features.Commands.AppUserCommands.LoginUser
{
    public sealed class LoginUserCommandResponse
    {
        public TokenDTO TokenDTO { get; set; }
    }
}
