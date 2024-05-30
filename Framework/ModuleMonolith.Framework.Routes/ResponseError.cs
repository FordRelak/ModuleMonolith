using ErrorOr;
using Microsoft.AspNetCore.Http;

namespace ModuleMonolith.Framework.Routes;
public record ResponseError(int StatusCode, string Message);

public static class ResponseErrorExtension
{
    public static ResponseError ToResponseError(this Error error)
        => new(StatusCodeHelper.FromError(error), error.Description);
}

public static class StatusCodeHelper
{
    public static int FromError(Error error)
        => error.NumericType switch
        {
            (int)ErrorType.Failure => StatusCodes.Status400BadRequest,
            (int)ErrorType.Unexpected => StatusCodes.Status400BadRequest,
            (int)ErrorType.Validation => StatusCodes.Status400BadRequest,
            (int)ErrorType.Conflict => StatusCodes.Status400BadRequest,
            (int)ErrorType.NotFound => StatusCodes.Status404NotFound,
            (int)ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            (int)ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError,
        };
}