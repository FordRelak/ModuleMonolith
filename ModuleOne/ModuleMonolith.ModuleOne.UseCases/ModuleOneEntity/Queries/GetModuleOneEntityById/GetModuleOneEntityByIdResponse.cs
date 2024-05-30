using ModuleMonolith.ModuleOne.Domain.Entities;

namespace ModuleMonolith.ModuleOne.UseCases.ModuleOneEntity.Queries.GetModuleOneEntityById;

internal record GetModuleOneEntityByIdResponse(Guid Id)
{
    public static GetModuleOneEntityByIdResponse Map(ModuleOneEntityOne entityOne)
        => new(entityOne.Id);
}
