using FluentValidation;

namespace server.Application.Features.Product.UpdateProduct;

public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p=>p.TypeValue).GreaterThan(0);
    }
}