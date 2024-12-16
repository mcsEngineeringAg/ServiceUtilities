using Serilog.Events;

namespace mcs.ServiceUtilitiesTests.Mocks
{
    internal class LogEventPropertyValueMock : LogEventPropertyValue
    {
        public LogEventPropertyValueMock(int value)
        {
            m_value = value;
        }

        public override void Render(TextWriter output, string? format = null, IFormatProvider? formatProvider = null)
        {
            output.Write(m_value);
            return;
        }

        private int m_value = 0;
    }
}
