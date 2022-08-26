
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection Add(this IServiceCollection services) =>
            services.AddTransient<IFileHandler, FileHandler>();
    }
}
