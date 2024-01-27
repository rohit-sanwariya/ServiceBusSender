using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Text.Json;

namespace ServiceBusSender.Services;

public class QueueService : IQueueService
{
    private readonly IConfiguration _config;

    public QueueService(IConfiguration configuration)
    {
        _config = configuration;
    }
    public async Task SendMessageAsync<T>(T serviceBusMessage, string queueName)
    {
        QueueClient? client = new QueueClient(_config.GetConnectionString("AzureServiceBus"), queueName);
        string? body = JsonSerializer.Serialize<T>(serviceBusMessage);
        Message? message = new Message(Encoding.UTF8.GetBytes(body));
        await client.SendAsync(message);
    }
}
