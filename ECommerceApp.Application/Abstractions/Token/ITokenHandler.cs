using ECommerceApp.Application.DTOs;

namespace ECommerceApp.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        TokenDTO CreateAccessToken(int minute);
    }
}
