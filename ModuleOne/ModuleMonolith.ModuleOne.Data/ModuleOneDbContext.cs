using Microsoft.EntityFrameworkCore;
using ModuleMonolith.ModuleOne.Domain.Entities;

namespace ModuleMonolith.ModuleOne.Data;

internal class ModuleOneDbContext(DbContextOptions<ModuleOneDbContext> options) : DbContext(options), IModuleOneDataContext
{
    public DbSet<ModuleOneEntityOne> ModuleOneEntityOnes { get; set; }
}
