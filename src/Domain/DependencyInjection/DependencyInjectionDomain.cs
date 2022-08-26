using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.DependencyInjection
{
    public static class DependencyInjectionDomain
    {
        public static void Add(this IServiceCollection services) =>
            services.AddSingleton<IProcessFile, ProcessFile>()
                    .AddSingleton<IReadFile, ReadFile>();
    }
}
