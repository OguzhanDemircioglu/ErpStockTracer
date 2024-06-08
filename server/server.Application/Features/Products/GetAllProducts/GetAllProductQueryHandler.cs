using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Products.GetAllProducts;

public sealed class GetAllProductQueryHandler(
    IProductRespository respository): IRequestHandler<GetAllProductQuery, Result<List<Product>>>
{
    public async Task<Result<List<Product>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        List<Product> products =
            await respository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);

        return products;
    }
}