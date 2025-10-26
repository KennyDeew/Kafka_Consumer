using Confluent.Kafka;
using Kafka_Consumer.Deserializers;
using Kafka_Consumer.Models;
using Kafka_Consumer.Options;
using Microsoft.Extensions.Logging;

namespace Kafka_Consumer.Consumers
{
    public sealed class BaseConsumer<TKey, TValue> where TValue : IKafkaFinancialReport<Guid>
    {
        private ILogger _logger;

        public IConsumer<TKey, TValue> Consumer { get; }

        public BaseConsumer(KafkaOptions kafkaOptions, ILogger logger, string groupId)
        {
            _logger = logger;
            var consumerConfig = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = kafkaOptions.BootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false,
            };
            ConsumerBuilder<TKey, TValue> consumerBuilder = new ConsumerBuilder<TKey, TValue>(consumerConfig);
            Consumer = consumerBuilder
                .SetErrorHandler((_, error) => _logger.LogError(error.Reason))
                .SetLogHandler((_, message) =>
                {
                    _logger.LogInformation(message.Message);
                })
                .SetKeyDeserializer((IDeserializer<TKey>)Confluent.Kafka.Deserializers.Utf8)
                .SetValueDeserializer(new KafkaMessageDeserializer<TValue>())
                .Build();
        }
    }
}
