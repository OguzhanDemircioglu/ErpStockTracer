using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.RecipeDetails.GetByIdRecipeWithDetailsQuery;

internal sealed class GetByIdRecipeWithDetailsQueryHandler(IRecipeRepository repository)
    : IRequestHandler<GetByIdRecipeWithDetailsQuery, Result<Recipe>>
{
    public async Task<Result<Recipe>> Handle(GetByIdRecipeWithDetailsQuery request,
        CancellationToken cancellationToken)
    {
        Recipe? recipe =
            await repository
                .Where(p => p.Id == request.Id)
                .Include(p => p.Product)
                .Include(p => p.Details!.OrderBy(p => p.Product!.Name))
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(cancellationToken);

        return recipe ?? Result<Recipe>.Failure("Reçete Bulunamadı");
    }
}