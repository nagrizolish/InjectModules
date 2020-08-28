using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleLib;

namespace InjectModules.Tests
{
    class TestInjectModuleInternal : IInjectModule
    {
        public IServiceCollection Load(IServiceCollection services,
                                       IConfiguration cnf = null)
        {
            services.AddScoped<ITestService<int>, TestService<int>>();

            return services;
        }
    }
}
