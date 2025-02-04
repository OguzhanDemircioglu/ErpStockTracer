﻿using FluentValidation;

namespace server.Application.Features.Products.UpdateProduct;

public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p=>p.TypeValue).GreaterThan(0);
    }
}