using ECommerceApp.Application.DTOs;

namespace ECommerceApp.Application.Services
{
    public interface IAuthService
    {
        Task<TokenDTO> GoogleLoginAsync(string idToken, string provider, int accessTokenLifeTime);
        Task<TokenDTO> LoginAsync(string userNameOrEmail, string password,int accessTokenLifeTime);
    }
}
