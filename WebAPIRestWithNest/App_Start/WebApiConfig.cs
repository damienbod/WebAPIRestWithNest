using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;
using Damienbod.BusinessLayer.Providers;
using Damienbod.LogProvider;
using Microsoft.Practices.Unity;
using WebAPIRestWithNest.App_Start;

namespace WebAPIRestWithNest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Services.Add(typeof(IExceptionLogger), new SlabLogExceptionLogger(UnityConfig.GetConfiguredContainer().Resolve<ILogProvider>()));
           
            RegisterFilterProviders(config);
        }

        public static void RegisterFilterProviders(HttpConfiguration config)
        {
            // Add Unity filters provider
            var providers = config.Services.GetFilterProviders().ToList();
            config.Services.Add(typeof(System.Web.Http.Filters.IFilterProvider), new WebApiUnityActionFilterProvider(UnityConfig.GetConfiguredContainer()));
            var defaultprovider = providers.First(p => p is ActionDescriptorFilterProvider);
            config.Services.Remove(typeof(System.Web.Http.Filters.IFilterProvider), defaultprovider);
        }
    }
}
