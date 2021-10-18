using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using P7Client.Data;

namespace P7Client.Misc
{
    public class KafkaConsumer : IHostedService
    {
        private readonly string topic = "quickstart-events";
        private readonly ReactiveCollections rc;

        public KafkaConsumer(ReactiveCollections rc)
        {
            this.rc = rc;
        }

        private Task Consume(CancellationToken cancellationToken)
        {
            var rand = new Random();
            var conf = new ConsumerConfig
            {
                GroupId = "test_consumer_group_" + rand.Next().ToString(),
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };


            using (var consumer = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                consumer.Subscribe(topic);

                while (!cancellationToken.IsCancellationRequested)
                {
                    var consumeResult = consumer.Consume();
                    rc.subjects.OnNext(consumeResult.Message.Value);
                    Console.WriteLine(consumeResult.Message.Value);
                }

                consumer.Close();
            }

            return Task.CompletedTask;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() => Consume(cancellationToken));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.rc.subjects.Dispose();
            return Task.CompletedTask;
        }
    }
}
