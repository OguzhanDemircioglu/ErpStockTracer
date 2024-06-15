using GenericRepository;
using server.Domain.Entities;
using server.Domain.Repositories;
using server.Infrastructure.Context;

namespace server.Infrastructure.Repositories;

internal sealed class DepotRepository(ApplicationDbContext context)
    : Repository<Depot,ApplicationDbContext>(context), IDepotRepository;