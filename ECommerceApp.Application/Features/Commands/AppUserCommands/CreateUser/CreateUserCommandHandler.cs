using ECommerceApp.Application.DTOs.UserDTOs;
using ECommerceApp.Application.Exceptions;
using ECommerceApp.Application.Services;
using ECommerceApp.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Application.Features.Commands.AppUserCommands.CreateUser
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private IUserService _userService;
        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserDTO createUserDTO = new()
            {
                Email = request.Email,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                UserName = request.UserName
            };

            return await _userService.CreateAsync(createUserDTO);
        }
    }
}
