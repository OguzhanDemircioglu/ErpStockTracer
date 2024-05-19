using FluentValidation;

namespace server.Application.Features.Customers.CreateCustomer;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(p => p.TaxNumber).MinimumLength(10).MaximumLength(11);
    }
}