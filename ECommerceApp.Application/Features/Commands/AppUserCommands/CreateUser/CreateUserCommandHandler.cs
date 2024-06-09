using ECommerceApp.Application.Exceptions;
using ECommerceApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Application.Features.Commands.AppUserCommands.CreateUser
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(new AppUser
            {
                Id = new Guid().ToString(),
                Email = request.Email,
                UserName = request.UserName

            }, request.Password);

            if (result.Succeeded)
                return new CreateUserCommandResponse() { Successeded = true, Message = "Created user" };

            throw new UserCreateFailedException();


        }
    }
}
