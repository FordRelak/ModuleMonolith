using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ModuleMonolith.Framework.Common;

namespace ModuleMonolith.Framework.Data.PostgreSQL;
public class FrameworkDataPostgreSQLModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.TryAddScoped<IDbConnectionProvider>(provider => new PostgreDbConnectionProvider(Configuration.GetConnectionString("Postgre")!));
    }
}
