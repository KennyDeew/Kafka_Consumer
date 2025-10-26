using Confluent.Kafka;
using Kafka_Consumer.Models;
using Kafka_Consumer.Options;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka_Consumer.Consumers
{
    public class FinReportCreatedMessageConsumer : ConsumerBackgroundService<string, FinancialReportCreatedMessage>
    {
        private readonly ILogger<FinReportCreatedMessageConsumer> _logger;

        public FinReportCreatedMessageConsumer(
            ILogger<FinReportCreatedMessageConsumer> logger,
            ApplicationOptions applicationOptions)
            : base(logger, applicationOptions)
        {
            TopicName = "created_financial_reports";
            _logger = logger;
        }

        protected override string TopicName { get; }

        protected override Task HandleAsync(ConsumeResult<string, FinancialReportCreatedMessage> message, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Message for financial report with shareCardId {message.Message.Key} received");
            return Task.CompletedTask;
        }
    }
}
