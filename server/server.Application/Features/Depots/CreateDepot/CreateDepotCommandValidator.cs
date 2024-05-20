using FluentValidation;

namespace server.Application.Features.Depots.CreateDepot;

public sealed class CreateDepotCommandValidator : AbstractValidator<CreateDepotCommand>
{
    public CreateDepotCommandValidator()
    {
        RuleFor(p => p.Town).MinimumLength(2);
    }
}