using Serilog.Core;
using Serilog.Events;

namespace mcs.ServiceUtilities.Logging
{
    /// <summary>
    /// Enrich Log messages with a message ID
    /// </summary>
    public class MessageIdEnricher : ILogEventEnricher
    {
        /// <summary>Enrich the log event.</summary>
        /// <param name="logEvent">The log event to enrich.</param>
        /// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var enrichProperty = propertyFactory
                .CreateProperty(
                    "MessageId",
                    mMessageIdCounter);

            logEvent.AddOrUpdateProperty(enrichProperty);
            mMessageIdCounter++;
        }

        private int mMessageIdCounter = 1;
    }
}
