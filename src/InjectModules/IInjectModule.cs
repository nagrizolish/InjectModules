using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InjectModules
{
    public interface IInjectModule
    {
        IServiceCollection Load(IServiceCollection services, IConfiguration cnf = null);
    }
}
