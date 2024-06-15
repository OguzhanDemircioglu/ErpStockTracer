using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Depots.GetAllDepots;

public sealed class GetAllDepotQueryHandler(
    IDepotRepository depotRepository): IRequestHandler<GetAllDepotQuery, Result<List<Depot>>>
{
    public async Task<Result<List<Depot>>> Handle(GetAllDepotQuery request, CancellationToken cancellationToken)
    {
        List<Depot> depots = await depotRepository.GetAll().OrderBy(p => p.Name).ToListAsync(
            cancellationToken);

        return depots;
    }
}