using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Data
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterDataAccessLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TestAppContext>(options => options.UseSqlServer(connectionString));

        }
    }
}
