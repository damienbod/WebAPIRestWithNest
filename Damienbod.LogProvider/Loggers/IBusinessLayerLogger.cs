namespace Damienbod.LogProvider.Loggers
{
    public interface IBusinessLayerLogger
    {
        void Critical(string message);
        void Error(string message);
        void Informational(string message);
        void LogAlways(string message);
        void Verbose(string message);
        void Warning(string message);
    }
}