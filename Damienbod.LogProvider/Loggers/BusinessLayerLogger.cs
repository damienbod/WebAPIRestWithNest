using Damienbod.BusinessLayer.Attributes.MVC5UnitySlab.Business.Attributes;
using Damienbod.LogProvider.Events;

namespace Damienbod.LogProvider.Loggers
{
    [Singleton]
    public class BusinessLayerLogger : IBusinessLayerLogger
    {
        public void Critical(string message)
        {
            ServiceLayerEvents.Log.Critical(message);
        }

        public void Error(string message)
        {
            ServiceLayerEvents.Log.Error(message);
        }

        public void Informational(string message)
        {
            ServiceLayerEvents.Log.Informational(message);
        }

        public void LogAlways(string message)
        {
            ServiceLayerEvents.Log.LogAlways(message);
        }

        public void Verbose(string message)
        {
            ServiceLayerEvents.Log.Verbose(message);
        }

        public void Warning(string message)
        {
            ServiceLayerEvents.Log.Warning(message);
        }
    }
}