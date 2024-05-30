using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleMonolith.Framework.Common;

public static class ModuleExtensions
{
    public static void RegisterModule<T>(this IServiceCollection services, IConfiguration configuration) where T : Module
    {
        var module = Activator.CreateInstance<T>();

        module.Configuration = configuration;

        module.Load(services);
    }
}
