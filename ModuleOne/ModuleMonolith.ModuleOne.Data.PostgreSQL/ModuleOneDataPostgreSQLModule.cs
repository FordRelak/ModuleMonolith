using Microsoft.Extensions.DependencyInjection;
using ModuleMonolith.Framework.Common;
using ModuleMonolith.Framework.Data.PostgreSQL;

namespace ModuleMonolith.ModuleOne.Data.PostgreSQL;
public class ModuleOneDataPostgreSQLModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.RegisterDbContext<IModuleOneDataContext, ModuleOneDbContext>();
    }
}
