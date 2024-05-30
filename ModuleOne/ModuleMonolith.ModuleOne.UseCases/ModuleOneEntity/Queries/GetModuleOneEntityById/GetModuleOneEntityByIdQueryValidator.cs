using FluentValidation;

namespace ModuleMonolith.ModuleOne.UseCases.ModuleOneEntity.Queries.GetModuleOneEntityById;

internal class GetModuleOneEntityByIdQueryValidator : AbstractValidator<GetModuleOneEntityByIdQuery>
{
    public GetModuleOneEntityByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotNull()
            .NotEmpty();
    }
}
