using Infrastructure.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Infrastructure.Services
{
    public class PublishRabbitMq : IPublish, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public PublishRabbitMq()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection ??= factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public Task Publish<T>(T value, CancellationToken cancellationToken)
        {
            _channel.QueueDeclare(queue: "files", exclusive: false);
            var json = JsonConvert.SerializeObject(value);
            var body = Encoding.UTF8.GetBytes(json);
            _channel.BasicPublish(exchange: "", routingKey: "files", body: body);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _connection?.Close();
            GC.SuppressFinalize(this);
        }
    }
}
