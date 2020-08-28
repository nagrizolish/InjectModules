using System;
using InjectModules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleLib
{
    public class TestInjectModuleExternal2 : IInjectModule
    {
        public IServiceCollection Load(IServiceCollection services, IConfiguration cnf = null)
        {
            services.AddScoped<ITestService<DateTime>, TestService<DateTime>>();

            return services;
        }
    }
}
