using Confluent.Kafka;
using Kafka_Consumer.Models;
using System.Text.Json;

namespace Kafka_Consumer.Deserializers
{
    public class KafkaMessageDeserializer<T> : IDeserializer<T> where T : IKafkaFinancialReport<Guid>
    {
        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            return JsonSerializer.Deserialize<T>(data.ToArray());
        }
    }
}
