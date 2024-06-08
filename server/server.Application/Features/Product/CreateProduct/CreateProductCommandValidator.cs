using FluentValidation;

namespace server.Application.Features.Product.CreateProduct;

public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p=>p.TypeValue).GreaterThan(0);
    }
}