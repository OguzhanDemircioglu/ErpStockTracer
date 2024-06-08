using FluentValidation;

namespace server.Application.Features.Products.CreateProduct;

public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p=>p.TypeValue).GreaterThan(0);
    }
}