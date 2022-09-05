using Domain.EventHandlers;
using Domain.EventHandlers.Events;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.DependencyInjection
{
    public static class DependencyInjectionDomain
    {
        public static void Add(this IServiceCollection services) =>
            services.AddTransient<IProcessFile, ProcessFile>()
                    .AddTransient<IReadFile, ReadFile>()
                    .AddTransient<IEventHandler<FileLineEvent>, FileLineHandler>();
    }
}
