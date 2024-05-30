using ErrorOr;
using MediatR;

namespace ModuleMonolith.ModuleOne.UseCases.ModuleOneEntity.Queries.GetModuleOneEntityById;
internal record GetModuleOneEntityByIdQuery(Guid Id) : IRequest<ErrorOr<GetModuleOneEntityByIdResponse>>;
