using ECommerceApp.Application.Abstractions.Token;
using ECommerceApp.Application.DTOs;
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
        private readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<AppUser> userManager,
                                       SignInManager<AppUser> signInManager,
                                       ITokenHandler tokenHandler)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _tokenHandler = tokenHandler;
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
            {
                TokenDTO token = _tokenHandler.CreateAccessToken(5);

                return new LoginUserCommandResponse() { TokenDTO = token };
            }
            throw new UnauthorizedAccessException();

        }
    }
}
