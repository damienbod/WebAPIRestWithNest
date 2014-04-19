using System.Web.Http.ExceptionHandling;
using Damienbod.BusinessLayer.Providers;

namespace WebAPIRestWithNest
{
    public class SlabLogExceptionLogger : ExceptionLogger
    {
        private readonly ILogProvider _logProvider;

        public SlabLogExceptionLogger(ILogProvider logProvider)
        {
            _logProvider = logProvider;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _logProvider.ServiceCritical(string.Format("{0}, {1}, {2}", context.Request.Method, context.Request.RequestUri, context.Exception.Message));
        }
    }
}