using ECommerceApp.Application.Abstractions.Token;
using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Exceptions;
using ECommerceApp.Application.Services;
using ECommerceApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Application.Features.Commands.AppUserCommands.LoginUser
{
    public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthService _authService;
        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.EmailOrUserName, request.Password, 10);
            return new()
            {
                TokenDTO = token
            };
        }
    }
}
