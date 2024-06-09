using MediatR;
using TS.Result;

namespace server.Application.Features.RecipeDetails.CreateRecipeDetail;

public sealed record CreateRecipeDetailCommand(
    Guid RecipeId,
    Guid ProductId,
    double Quantity): IRequest<Result<string>>;