using Infrastructure.Persistence.EventProcessor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.RabbitMqClient
{
    public class RabbitMqSubscriber : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly string _queueName;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private IEventProcessor _eventProcessor;

        public RabbitMqSubscriber(IConfiguration configuration, IEventProcessor eventProcessor)
        {
            _configuration = configuration;
            _connection = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMqHost"],
                Port = Int32.Parse(_configuration["RabbitMqPort"])
            }.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName, exchange: "trigger", routingKey: "");
            _eventProcessor = eventProcessor;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ModuleHandle, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());
                _eventProcessor.Process(message);
            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
