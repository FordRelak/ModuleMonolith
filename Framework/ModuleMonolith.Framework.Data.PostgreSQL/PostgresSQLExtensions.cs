using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleMonolith.Framework.Data.PostgreSQL;

public static class PostgresSQLExtensions
{
    public static IServiceCollection RegisterDbContext<TInterface, TDbContext>(this IServiceCollection services)
        where TInterface : class
        where TDbContext : DbContext, TInterface
    {
        services.AddDbContext<TDbContext>((provider, opt) =>
        {
            var dbConnectionProvider = provider.GetRequiredService<IDbConnectionProvider>();
            opt.UseNpgsql(dbConnectionProvider.DbConnection);
        });

        services.AddScoped<TInterface>(provider =>
        {
            var dbContext = provider.GetRequiredService<TDbContext>();

            return dbContext;
        });

        return services;
    }
}
