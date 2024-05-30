using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using ModuleMonolith.Framework.Routes;
using ModuleMonolith.ModuleOne.UseCases.ModuleOneEntity.Queries.GetModuleOneEntityById;
using System.Net.Mime;

namespace ModuleMonolith.ModuleOne.Routes.EntityOne;
internal class GetEntityOneById(IMediator mediator) : Endpoint<GetModuleOneEntityByIdQuery, GetModuleOneEntityByIdResponse>
{
    public override void Configure()
    {
        Get("/api/module-one/entity-one/{Id}");
        Validator<GetModuleOneEntityByIdQueryValidator>();
        AllowAnonymous();
        Description(b => b.Produces<ResponseError>(400, MediaTypeNames.Application.Json)
                          .Produces<GetModuleOneEntityByIdResponse>(200, MediaTypeNames.Application.Json));
    }

    public override async Task HandleAsync(GetModuleOneEntityByIdQuery req, CancellationToken ct)
    {
        var response = await mediator.Send(req, ct);

        await response.SwitchAsync(v => SendOkAsync(v), e => this.SendCodeAsync(e));
    }
}
