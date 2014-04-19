using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Damienbod.BusinessLayer.Providers;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
using WebAPIRestWithNest.App_Start;

namespace WebAPIRestWithNest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());
            config.Services.Add(typeof(IExceptionLogger), new SlabLogExceptionLogger(UnityConfig.GetConfiguredContainer().Resolve<ILogProvider>()));

            WebApiUnityActionFilterProvider.RegisterFilterProviders(config);
        }
    }
}
