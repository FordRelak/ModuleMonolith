using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleMonolith.Framework.Common;

public abstract class Module
{
    public IConfiguration Configuration { get; set; } = default!;

    public abstract void Load(IServiceCollection services);
}
