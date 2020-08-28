using InjectModules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleLib
{
    public class TestInjectModuleExternal1 : IInjectModule
    {
        public IServiceCollection Load(IServiceCollection services, IConfiguration cnf = null)
        {
            services.AddScoped<ITestService<string>, TestService<string>>();

            return services;
        }
    }
}
