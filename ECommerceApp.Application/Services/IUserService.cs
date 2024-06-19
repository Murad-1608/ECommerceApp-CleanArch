using ECommerceApp.Application.DTOs.UserDTOs;
using ECommerceApp.Application.Features.Commands.AppUserCommands.CreateUser;
using ECommerceApp.Domain.Entities.Identity;

namespace ECommerceApp.Application.Services
{
    public interface IUserService
    {
        Task<CreateUserCommandResponse> CreateAsync(CreateUserDTO Dto);
        Task UpdateRefleshToken(string refleshToken, AppUser user, DateTime AccessTokenDate, int refleshTokenLifeTime);

    }
}
