
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.DependencyInjection
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection Add(this IServiceCollection services) =>
            services.AddTransient<IFileHandler, FileHandler>()
                    .AddSingleton<IPublish, PublishRabbitMq>()
                    .AddSingleton<ISubscribe, SubscribeRabbitMq>();
    }
}
