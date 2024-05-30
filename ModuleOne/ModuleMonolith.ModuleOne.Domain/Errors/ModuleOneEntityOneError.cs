using ErrorOr;

namespace ModuleMonolith.ModuleOne.Domain.Errors;

internal static class ModuleOneEntityOneError
{
    public static Error NotFound
        => Error.NotFound(
            code: "ModuleOneEntityOne.NotFound",
            description: "ModuleOneEntityOne not found.");
}
