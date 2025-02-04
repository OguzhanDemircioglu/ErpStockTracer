﻿using MediatR;
using server.Domain.Entities;
using TS.Result;

namespace server.Application.Features.RecipeDetails.GetByIdRecipeWithDetailsQuery;

public sealed record GetByIdRecipeWithDetailsQuery(
    Guid Id): IRequest<Result<Recipe>>;