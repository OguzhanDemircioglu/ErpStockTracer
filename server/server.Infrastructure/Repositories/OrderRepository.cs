using GenericRepository;
using server.Domain.Entities;
using server.Domain.Repositories;
using server.Infrastructure.Context;

namespace server.Infrastructure.Repositories;

internal sealed class OrderRepository(ApplicationDbContext context)
    : Repository<Order,ApplicationDbContext>(context), IOrderRepository;