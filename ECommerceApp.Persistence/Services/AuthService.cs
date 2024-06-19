using Azure.Core;
using ECommerceApp.Application.Abstractions.Token;
using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Exceptions;
using ECommerceApp.Application.Features.Commands.AppUserCommands.LoginUser;
using ECommerceApp.Application.Services;
using ECommerceApp.Domain.Entities.Identity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;
        public AuthService(UserManager<AppUser> userManager,
                           ITokenHandler tokenHandler,
                           SignInManager<AppUser> signInManager,
                           IUserService userService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            this.signInManager = signInManager;
            _userService = userService;
        }

        public async Task<TokenDTO> GoogleLoginAsync(string idToken, string provider, int accessTokenLifeTime)
        {
            var setting = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { "ClientID" }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, setting);
            var info = new UserLoginInfo(provider, payload.Subject, provider);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = payload.Email,
                        UserName = payload.Email,
                    };
                    var identityResult = await _userManager.CreateAsync(user);

                    result = identityResult.Succeeded;
                }
            }

            if (result)
                await _userManager.AddLoginAsync(user, info);
            else
                throw new Exception("Invalid external authentication.");


            TokenDTO tokenDTO = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
            return tokenDTO;
        }

        public async Task<TokenDTO> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime)
        {
            var user = await _userManager.FindByNameAsync(userNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(userNameOrEmail);

            if (user == null)
                throw new NotFoundUserException("User name or password invalid");

            var check = await signInManager.CheckPasswordSignInAsync(user, password, false);

            if (check.Succeeded)
            {
                TokenDTO token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);

                await _userService.UpdateRefleshToken(token.RefleshToken, user, token.Expiration, 50);

                return token;
            }
            throw new UnauthorizedAccessException();
        }
    }
}
