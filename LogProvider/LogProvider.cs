using BusinessLayer.Providers;
using LogProvider.Loggers;

namespace LogProvider
{
    public class LogProvider : ILogProvider
    {
        private readonly IServiceLayerLogger _serviceLayerLogger;
        private readonly IElasticSearchProviderLogger _elasticSearchProviderLogger;
        private readonly IBusinessLayerLogger _businessLayerLogger;

        public LogProvider(IServiceLayerLogger serviceLayerLogger, IElasticSearchProviderLogger elasticSearchProviderLogger, IBusinessLayerLogger businessLayerLogger)
        {
            _serviceLayerLogger = serviceLayerLogger;
            _elasticSearchProviderLogger = elasticSearchProviderLogger;
            _businessLayerLogger = businessLayerLogger;
        }

        public void ServiceCritical(string message)
        {
            _serviceLayerLogger.Critical(message);
        }

        public void ServiceError(string message)
        {
            _serviceLayerLogger.Error(message);
        }

        public void ServiceInformational(string message)
        {
            _serviceLayerLogger.Informational(message);
        }

        public void ServiceLogAlways(string message)
        {
            _serviceLayerLogger.LogAlways(message);
        }

        public void ServiceVerbose(string message)
        {
            _serviceLayerLogger.Verbose(message);
        }

        public void ServiceWarning(string message)
        {
            _serviceLayerLogger.Warning(message);
        }

        public void ElasticSearchProviderCritical(string message)
        {
            _elasticSearchProviderLogger.Critical(message);
        }

        public void ElasticSearchProviderError(string message)
        {
            _elasticSearchProviderLogger.Error(message);
        }

        public void ElasticSearchProviderInformational(string message)
        {
            _elasticSearchProviderLogger.Informational(message);
        }

        public void ElasticSearchProviderLogAlways(string message)
        {
            _elasticSearchProviderLogger.LogAlways(message);
        }

        public void ElasticSearchProviderVerbose(string message)
        {
            _elasticSearchProviderLogger.Verbose(message);
        }

        public void ElasticSearchProviderWarning(string message)
        {
            _elasticSearchProviderLogger.Warning(message);
        }

        public void BusinessLayerCritical(string message)
        {
            _businessLayerLogger.Critical(message);
        }

        public void BusinessLayerError(string message)
        {
            _businessLayerLogger.Error(message);
        }

        public void BusinessLayerInformational(string message)
        {
            _businessLayerLogger.Informational(message);
        }

        public void BusinessLayerLogAlways(string message)
        {
            _businessLayerLogger.LogAlways(message);
        }

        public void BusinessLayerVerbose(string message)
        {
            _businessLayerLogger.Verbose(message);
        }

        public void BusinessLayerWarning(string message)
        {
            _businessLayerLogger.Warning(message);
        }
    }
}
