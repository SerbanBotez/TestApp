using Microsoft.Extensions.DependencyInjection;

namespace TestApp.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<LoginService>();
        }
    }
}
