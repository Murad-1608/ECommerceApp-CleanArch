using Azure.Core;
using ECommerceApp.Application.DTOs.UserDTOs;
using ECommerceApp.Application.Exceptions;
using ECommerceApp.Application.Features.Commands.AppUserCommands.CreateUser;
using ECommerceApp.Application.Services;
using ECommerceApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Persistence.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<AppUser> _userManager;
        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<CreateUserCommandResponse> CreateAsync(CreateUserDTO Dto)
        {
            AppUser user = new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = Dto.Email,
                UserName = Dto.UserName

            };
            var result = await _userManager.CreateAsync(user, Dto.Password);

            if (result.Succeeded)
                return new CreateUserCommandResponse() { Successeded = true, Message = "Created user" };

            throw new UserCreateFailedException();
        }

        public async Task UpdateRefleshToken(string refleshToken, AppUser user, DateTime accessTokenDate, int refleshTokenLifeTime)
        {
            if (user != null)
            {
                user.RefleshToken = refleshToken;
                user.RefleshTokenEndDate = accessTokenDate.AddSeconds(refleshTokenLifeTime);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new NotFoundUserException("Not Found User");
        }
    }
}
