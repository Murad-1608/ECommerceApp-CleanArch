using ECommerceApp.Application.Abstractions.Storage;
using ECommerceApp.Application.Abstractions.Token;
using ECommerceApp.Infrastructure.Enums;
using ECommerceApp.Infrastructure.Services.Storage.Azure;
using ECommerceApp.Infrastructure.Services.Storage.Local;
using ECommerceApp.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddStorage(this IServiceCollection services, StorageType type)
        {
            switch (type)
            {
                case StorageType.Local:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    services.AddScoped<IStorage, AzureStorage>();
                    break;
            }
        }

        public static void AddTokenService(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
