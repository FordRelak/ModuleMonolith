using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ModuleMonolith.Framework.Common;

namespace ModuleMonolith.Framework.Data;
public class FrameworkDataModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.TryAddScoped<IDbTransactionProvider, DbTransactionProvider>();
    }
}
