using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Application.Features.Products.GetAllProducts;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Recipes.GetAllRecipe;

public class GetAllRecipeQueryHandler(
    IRecipeRepository respository): IRequestHandler<GetAllRecipeQuery, Result<List<Recipe>>>
{
    public async Task<Result<List<Recipe>>> Handle(GetAllRecipeQuery request, CancellationToken cancellationToken)
    {
        List<Recipe> recipes =
            await respository.GetAll()
                .Include(r=>r.Product)
                .OrderBy(p => p.Product!.Name)
                .ToListAsync(cancellationToken);

        return recipes;
    }
}