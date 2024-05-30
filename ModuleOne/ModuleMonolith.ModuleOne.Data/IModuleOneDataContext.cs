using Microsoft.EntityFrameworkCore;
using ModuleMonolith.ModuleOne.Domain.Entities;

namespace ModuleMonolith.ModuleOne.Data;

internal interface IModuleOneDataContext
{
    DbSet<ModuleOneEntityOne> ModuleOneEntityOnes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
