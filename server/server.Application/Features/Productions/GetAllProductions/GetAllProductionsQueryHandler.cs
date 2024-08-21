using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Productions.GetAllProductions;

internal sealed class GetAllProductionsQueryHandler(
    IProductionRepository repository) : IRequestHandler<GetAllProductionsQuery, Result<List<Production>>>
{
    public async Task<Result<List<Production>>> Handle(GetAllProductionsQuery request, CancellationToken cancellationToken)
    {
        List<Production> orders = await repository.GetAll()
            .Include(p=> p.Product)
            .Include(z=> z.Depot)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync(cancellationToken);
        
        return orders;
    }
}