using Infrastructure.Interfaces;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    public class SubscribeRabbitMq : ISubscribe
    {

        public async Task Subscribe<T>(Func<T, CancellationToken, Task> action, CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                DispatchConsumersAsync = true,
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "files", exclusive: false);
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += (_, eventArgs) =>
            {
                var bodyToString = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
                var body = JsonConvert.DeserializeObject<T>(bodyToString);
                return action(body, cancellationToken);
            };
            channel.BasicConsume(queue: "files", autoAck: true, consumer: consumer);
            await Task.Delay(Timeout.Infinite, cancellationToken);
        }
    }
}
