namespace Damienbod.LogProvider.Loggers
{
    public interface IElasticSearchProviderLogger
    {
        void Critical(string message);
        void Error(string message);
        void Informational(string message);
        void LogAlways(string message);
        void Verbose(string message);
        void Warning(string message);
    }
}