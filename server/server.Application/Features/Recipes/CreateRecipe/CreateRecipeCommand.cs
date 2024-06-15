using MediatR;
using server.Domain.Dtos;
using TS.Result;

namespace server.Application.Features.Recipes.CreateRecipe;

public sealed record CreateRecipeCommand(
    Guid ProductId,
    List<RecipeDetailDto> Details): IRequest<Result<string>>;
    
