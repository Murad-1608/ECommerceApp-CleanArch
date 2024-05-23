using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerceApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection service)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
