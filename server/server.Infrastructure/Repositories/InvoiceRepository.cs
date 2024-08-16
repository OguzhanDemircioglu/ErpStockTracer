using GenericRepository;
using server.Domain.Entities;
using server.Domain.Repositories;
using server.Infrastructure.Context;

namespace server.Infrastructure.Repositories;

internal sealed class InvoiceRepository(ApplicationDbContext context)
 : Repository<Invoice, ApplicationDbContext>(context), IInvoiceRepository;