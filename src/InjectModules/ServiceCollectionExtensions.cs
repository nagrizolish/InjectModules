using System;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InjectModules.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterModule<TModule>(this IServiceCollection services,
                                                                      IConfiguration cnf = null)
            where TModule : IInjectModule
        {
            var moduleInstance = (TModule)FormatterServices.GetSafeUninitializedObject(typeof(TModule));

            return moduleInstance.Load(services, cnf);
        }

        public static IServiceCollection RegisterModule(this IServiceCollection services,
                                                             Type type,
                                                             IConfiguration cnf = null)
        {
            if (typeof(IInjectModule).IsAssignableFrom(type))
            {
                var moduleInstance = (IInjectModule)FormatterServices.GetSafeUninitializedObject(type);

                return moduleInstance.Load(services, cnf);
            }

            throw new ArgumentException($"Type of passed object must be assignable from {typeof(IInjectModule).FullName}");
        }

        public static IServiceCollection RegisterModules(this IServiceCollection services,
                                                              Type assemblyMarkerType,
                                                              IConfiguration cnf = null)
        {
            var assembly = assemblyMarkerType.Assembly;

            var modules = assembly.GetExportedTypes()
                                  .Where(x => typeof(IInjectModule).IsAssignableFrom(x));

            foreach (var moduleType in modules)
                services.RegisterModule(moduleType);

            return services;
        }
    }
}
