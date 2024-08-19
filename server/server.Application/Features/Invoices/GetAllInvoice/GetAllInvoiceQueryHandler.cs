using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Domain.Enums;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Invoices.GetAllInvoice;

internal sealed class GetAllInvoiceQueryHandler(
    IInvoiceRepository invoiceRepository) : IRequestHandler<GetAllInvoiceQuery, Result<List<Invoice>>>
{
    public async Task<Result<List<Invoice>>> Handle(GetAllInvoiceQuery request, CancellationToken cancellationToken)
    {
        List<Invoice> invoices =
            await invoiceRepository
                .Where(p => p.Type == InvoiceTypeEnum.FromValue(request.Type))
                .Include(p => p.Customer)
                .Include(p => p.Details!)
                .ThenInclude(p => p.Product)
                .Include(p => p.Details!)
                .ThenInclude(p => p.Depot)
                .OrderBy(p => p.Date)
                .ToListAsync(cancellationToken);

        return invoices;
    }
}