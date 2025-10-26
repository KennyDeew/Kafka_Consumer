namespace Kafka_Consumer.Models
{
    /// <summary>
    /// Интерфейс сообщения в Kafka по финансовому отчету
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IKafkaFinancialReport<TId>
    {
        /// <summary>
        /// Идентификатор акции, к которой относится финансовый отчет.
        /// </summary>
        TId ShareCardId { get; set; }
    }
}
