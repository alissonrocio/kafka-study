using Confluent.Kafka;
using System.Net;
using System.Text.Json;

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9093",
    ClientId = Dns.GetHostName(),
    SecurityProtocol = SecurityProtocol.Plaintext
};

using var producer = new ProducerBuilder<Null, string>(config).Build();

try
{
    while (true)
    {
        var msg = new
        {
            profileId = Guid.NewGuid(),
            latitude = new Random().NextDouble(),
            longitude = new Random().NextDouble(),
        };

        var dr = await producer.ProduceAsync("topic-1", new Message<Null, string> { Value = JsonSerializer.Serialize(msg) });

        Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");

        Thread.Sleep(5000);

    }
}
catch (ProduceException<Null, string> e)
{
    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
}





