using MediatR;
using TS.Result;

namespace server.Application.Features.Recipes.DeleteRecipe;

public sealed record DeleteRecipeByIdCommand(
    Guid Id): IRequest<Result<string>>;