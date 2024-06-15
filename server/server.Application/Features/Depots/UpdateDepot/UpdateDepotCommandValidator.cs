using FluentValidation;

namespace server.Application.Features.Depots.UpdateDepot;

public class UpdateDepotCommandValidator: AbstractValidator<UpdateDepotCommand>
{
    public UpdateDepotCommandValidator()
    {
        RuleFor(p => p.Town).MinimumLength(2);
    }
}