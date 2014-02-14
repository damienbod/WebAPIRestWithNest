namespace Damienbod.BusinessLayer.Providers
{
    public interface ILogProvider
    {
        void ServiceCritical(string message);
        void ServiceError(string message);
        void ServiceInformational(string message);
        void ServiceLogAlways(string message);
        void ServiceVerbose(string message);
        void ServiceWarning(string message);

        void ElasticSearchProviderCritical(string message);
        void ElasticSearchProviderError(string message);
        void ElasticSearchProviderInformational(string message);
        void ElasticSearchProviderLogAlways(string message);
        void ElasticSearchProviderVerbose(string message);
        void ElasticSearchProviderWarning(string message);

        void BusinessLayerCritical(string message);
        void BusinessLayerError(string message);
        void BusinessLayerInformational(string message);
        void BusinessLayerLogAlways(string message);
        void BusinessLayerVerbose(string message);
        void BusinessLayerWarning(string message);
        
    }
}
