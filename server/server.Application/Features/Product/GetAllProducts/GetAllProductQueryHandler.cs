using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Product.GetAllProducts;

public sealed class GetAllProductQueryHandler(
    IProductRespository respository): IRequestHandler<GetAllProductQuery, Result<List<Domain.Entities.Product>>>
{
    public async Task<Result<List<Domain.Entities.Product>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Entities.Product> products =
            await respository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);

        return products;
    }
}