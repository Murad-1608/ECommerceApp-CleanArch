using ECommerceApp.Application.Abstractions.Token;
using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Services;
using ECommerceApp.Domain.Entities.Identity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Application.Features.Commands.AppUserCommands.GoogleLogin
{
    public sealed class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IAuthService _authService;

        public GoogleLoginCommandHandler(UserManager<AppUser> userManager,
                                         ITokenHandler tokenHandler,
                                         IAuthService authService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.GoogleLoginAsync(request.IdToken, request.Provider, 5);

            return new()
            {
                Token = token
            };
        }
    }
}
