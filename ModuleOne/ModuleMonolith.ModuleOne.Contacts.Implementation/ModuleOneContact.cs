using ErrorOr;
using MediatR;
using ModuleMonolith.ModuleOne.Contacts.Dto;
using ModuleMonolith.ModuleOne.UseCases.ModuleOneEntity.Queries.GetModuleOneEntityById;

namespace ModuleMonolith.ModuleOne.Contacts.Implementation;
internal class ModuleOneContact(IMediator mediator) : IModuleOneContact
{
    public Task<ErrorOr<EntityOneDto>> GetEntityOneByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return mediator
            .Send(new GetModuleOneEntityByIdQuery(id), cancellationToken)
            .Then(r => new EntityOneDto(r.Id));
    }
}
