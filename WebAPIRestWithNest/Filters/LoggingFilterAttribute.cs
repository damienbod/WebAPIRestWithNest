using System.Diagnostics;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Damienbod.BusinessLayer.Providers;
using Microsoft.Practices.Unity;

namespace WebAPIRestWithNest.Filters
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        [Dependency]
        internal ILogProvider LogProvider { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // pre-processing
            LogProvider.ServiceVerbose(string.Format("{0}, HTTP: {1}", actionContext.Request.RequestUri, actionContext.Request.Method));
        }
 
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if((actionExecutedContext.Response != null))
            {
                var objectContent = actionExecutedContext.Response.Content as ObjectContent;
                if (objectContent != null)
                {
                    var type = objectContent.ObjectType; //type of the returned object
                    var value = objectContent.Value; //holding the returned value
                }
                LogProvider.ServiceVerbose(string.Format("{0}, HTTP STATUS CODE: {1}",
                    actionExecutedContext.Request.RequestUri, actionExecutedContext.Response.StatusCode));
            }           
        }
    }
}