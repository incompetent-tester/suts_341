using System;
using System.Collections.Generic;
using Confluent.Kafka;

namespace P7Service1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();

            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "test_consumer_group_" + rand.Next().ToString(),
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe(new List<String> { "quickstart-events" });

                try
                {
                    while (true)
                    {
                        var consumeResult = consumer.Consume();

                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("I received :");
                        Console.WriteLine(consumeResult.Message.Value);
                        Console.WriteLine("I shall save this in database or do something with it");

                        // Fill in the blank here to store in db
                    }
                }
                finally
                {
                    consumer.Close();
                }
            }
        }
    }
}
