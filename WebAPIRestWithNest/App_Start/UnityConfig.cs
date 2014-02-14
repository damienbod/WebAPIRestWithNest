using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Damienbod.BusinessLayer.Attributes.MVC5UnitySlab.Business.Attributes;
using Damienbod.BusinessLayer.Providers;
using Microsoft.Practices.Unity;

namespace WebAPIRestWithNest.App_Start
{
    
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        private const string ClassesToScan = "Damienbod";

        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static IEnumerable<Type> GetTypesWithCustomAttribute<T>(Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetCustomAttributes(typeof(T), true).Length > 0)
                    {
                        yield return type;
                    }
                }
            }
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            var myAssemblies =
                AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => a.FullName.StartsWith(ClassesToScan))
                    .ToArray();

            container.RegisterTypes(
                UnityConfig.GetTypesWithCustomAttribute<SingletonAttribute>(myAssemblies),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled,
                null
                ).RegisterTypes(
                    UnityConfig.GetTypesWithCustomAttribute<TransientLifetime>(myAssemblies),
                    WithMappings.FromMatchingInterface,
                    WithName.Default,
                    WithLifetime.Transient);
        }
    }
}
