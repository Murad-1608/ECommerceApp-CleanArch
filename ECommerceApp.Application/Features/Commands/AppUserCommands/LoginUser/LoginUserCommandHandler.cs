using ECommerceApp.Application.Exceptions;
using ECommerceApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Application.Features.Commands.AppUserCommands.LoginUser
{
    public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public LoginUserCommandHandler(UserManager<AppUser> userManager,
                                       SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.EmailOrUserName);
            if (user == null)
                user = await userManager.FindByEmailAsync(request.EmailOrUserName);

            if (user == null)
                throw new NotFoundUserException("User name or password invalid");

            var check = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (check.Succeeded)
                throw new NotImplementedException();
        }
    }
}
