using GenericRepository;
using server.Domain.Entities;
using server.Domain.Repositories;
using server.Infrastructure.Context;

namespace server.Infrastructure.Repositories;

internal sealed class StockMovementRepository(ApplicationDbContext context)
  : Repository<StockMovement, ApplicationDbContext>(context), IStockMovementRepository;