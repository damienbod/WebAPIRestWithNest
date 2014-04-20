using System.Web.Http;
using System.Web.Http.Batch;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Tracing;
using Damienbod.BusinessLayer.Providers;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
using WebApiContrib.Tracing.Slab;
using WebAPIRestWithNest.App_Start;

namespace WebAPIRestWithNest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpBatchRoute(
                routeName: "WebApiBatch",
                routeTemplate: "api/$batch",
                batchHandler: new DefaultHttpBatchHandler(GlobalConfiguration.DefaultServer));

            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());
            config.Services.Add(typeof (IExceptionLogger),
                new SlabLogExceptionLogger(UnityConfig.GetConfiguredContainer().Resolve<ILogProvider>()));

            config.EnableSystemDiagnosticsTracing();
            config.Services.Replace(typeof (ITraceWriter), new SlabTraceWriter());

            WebApiUnityActionFilterProvider.RegisterFilterProviders(config);
        }
    }
}
