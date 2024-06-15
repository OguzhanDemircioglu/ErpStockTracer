using MediatR;
using server.Domain.Entities;
using TS.Result;

namespace server.Application.Features.Recipes.GetAllRecipe;

public sealed record GetAllRecipeQuery: IRequest<Result<List<Recipe>>>;