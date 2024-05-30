using ErrorOr;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace ModuleMonolith.Framework.Routes;

public static class EndpointExtensions
{
    public static Task SendCodeAsync(this IEndpoint ep, List<Error> errors, CancellationToken ct = default)
    {
        var error = errors[0];
        var responseError = error.ToResponseError();

        ep.HttpContext.MarkResponseStart();
        ep.HttpContext.Response.StatusCode = responseError.StatusCode;
        ep.HttpContext.Response.WriteAsJsonAsync(responseError, ct);

        return ep.HttpContext.Response.StartAsync(ct);
    }
}
