using ErrorOr;
using ModuleMonolith.ModuleOne.Contacts.Dto;

namespace ModuleMonolith.ModuleOne.Contacts;
public interface IModuleOneContact
{
    Task<ErrorOr<EntityOneDto>> GetEntityOneByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
