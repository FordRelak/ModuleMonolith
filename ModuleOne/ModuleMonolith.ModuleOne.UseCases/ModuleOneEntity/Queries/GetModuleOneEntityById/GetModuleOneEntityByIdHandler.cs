using ErrorOr;
using MediatR;
using ModuleMonolith.ModuleOne.Data;
using ModuleMonolith.ModuleOne.Domain.Errors;

namespace ModuleMonolith.ModuleOne.UseCases.ModuleOneEntity.Queries.GetModuleOneEntityById;

internal class GetModuleOneEntityByIdHandler(ModuleOneDbContext context) : IRequestHandler<GetModuleOneEntityByIdQuery, ErrorOr<GetModuleOneEntityByIdResponse>>
{
    public async Task<ErrorOr<GetModuleOneEntityByIdResponse>> Handle(GetModuleOneEntityByIdQuery request, CancellationToken cancellationToken)
    {
        return (await context.ModuleOneEntityOnes
            .FindAsync([request.Id], cancellationToken))
            .ToErrorOr()
            .FailIf(
                entity => entity is null,
                ModuleOneEntityOneError.NotFound
            )
            .Then(GetModuleOneEntityByIdResponse.Map!);
    }
}
