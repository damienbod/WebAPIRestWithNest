using System.Diagnostics.Tracing;

namespace LogProvider.Events
{
    [EventSource(Name = "ServiceLayerEvents")]
    public class ServiceLayerEvents : EventSource
    {
        public static readonly ServiceLayerEvents Log = new ServiceLayerEvents();

        [Event(1, Message = "ServiceLayerEvents Critical: {0}", Level = EventLevel.Critical)]
        public void Critical(string message)
        {
            if (IsEnabled()) WriteEvent(1, message);
        }

        [Event(2, Message = "ServiceLayerEvents Error {0}", Level = EventLevel.Error)]
        public void Error(string message)
        {
            if (IsEnabled()) WriteEvent(2, message);
        }

        [Event(3, Message = "ServiceLayerEvents Informational {0}", Level = EventLevel.Informational)]
        public void Informational(string message)
        {
            if (IsEnabled()) WriteEvent(3, message);
        }

        [Event(4, Message = "ServiceLayerEvents LogAlways {0}", Level = EventLevel.LogAlways)]
        public void LogAlways(string message)
        {
            if (IsEnabled()) WriteEvent(4, message);
        }

        [Event(5, Message = "ServiceLayerEvents Verbose {0}", Level = EventLevel.Verbose)]
        public void Verbose(string message)
        {
            if (IsEnabled()) WriteEvent(5, message);
        }

        [Event(6, Message = "ServiceLayerEvents Warning {0}", Level = EventLevel.Warning)]
        public void Warning(string message)
        {
            if (IsEnabled()) WriteEvent(6, message);
        }
    }
}