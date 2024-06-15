using MediatR;
using TS.Result;

namespace server.Application.Features.RecipeDetails.UpdateRecipeDetail;

public sealed record UpdateRecipeDetailCommand(
    Guid Id,
    Guid ProductId,
    double Quantity):IRequest<Result<string>>;