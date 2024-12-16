using mcs.ServiceUtilities.Logging;
using mcs.ServiceUtilitiesTests.Mocks;
using Moq;
using Serilog.Core;
using Serilog.Events;
using Serilog.Parsing;

namespace mcs.ServiceUtilitiesTests
{
    public class MessageIdEnricherTests
    {
        [Fact]
        public void Enrich_LogTwoEntries_ConsecutiveNumbering()
        {
            var logEvents = new LogEvent(new DateTimeOffset(), LogEventLevel.Information, null, new MessageTemplate("test", new List<MessageTemplateToken>()), new List<LogEventProperty>());
            var propertyFactoryMock = new Mock<ILogEventPropertyFactory>();
            propertyFactoryMock.Setup(x => x.CreateProperty(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()))
                .Returns((string name, int value, bool _) => new LogEventProperty(name, new LogEventPropertyValueMock(value)));
            var enricher = new MessageIdEnricher();
            enricher.Enrich(logEvents, propertyFactoryMock.Object);

            Assert.Equal("1", logEvents.Properties["MessageId"].ToString());
            enricher.Enrich(logEvents, propertyFactoryMock.Object);
            Assert.Equal("2", logEvents.Properties["MessageId"].ToString());
        }
    }
}
