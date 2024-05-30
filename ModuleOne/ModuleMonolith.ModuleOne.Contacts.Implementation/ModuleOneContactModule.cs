using Microsoft.Extensions.DependencyInjection;
using ModuleMonolith.Framework.Common;

namespace ModuleMonolith.ModuleOne.Contacts.Implementation;
public class ModuleOneContactModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.AddScoped<IModuleOneContact, ModuleOneContact>();
    }
}
