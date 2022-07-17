using System;
using System.Collections.Generic;
using Confluent.Kafka;

var topics = "topic-1";

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9093",
    GroupId = "group-1",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

CancellationToken cancellationToken = new CancellationToken();

using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

consumer.Subscribe(topics);

while (!cancellationToken.IsCancellationRequested)
{
    var consumeResult = consumer.Consume(cancellationToken);

    Console.WriteLine($"Time: {DateTime.Now} OffSet: {consumeResult.Offset} Partition: {consumeResult.Partition} Value: {consumeResult.Message.Value.ToString()}");
}

consumer.Close();
