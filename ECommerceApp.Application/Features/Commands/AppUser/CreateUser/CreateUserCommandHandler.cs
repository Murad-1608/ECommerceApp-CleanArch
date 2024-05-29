using ECommerceApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Application.Features.Commands.AppUserCommands.CreateUser
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userManager.CreateAsync(new AppUser
            {
                Email = request.Email,
                UserName = request.UserName

            }, request.Password);

            return new CreateUserCommandResponse();
        }
    }
}
