using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Invoices.GetAllInvoice;

internal sealed class GetAllInvoiceQueryHandler(
    IInvoiceRepository repository) : IRequestHandler<GetAllInvoiceQuery, Result<List<Invoice>>>
{
    public async Task<Result<List<Invoice>>> Handle(GetAllInvoiceQuery request, CancellationToken cancellationToken)
    {
        List<Invoice> orders = await repository.Where(p => p.Type!.Value == request.Type)
            .OrderByDescending(r => r.Date)
            .ToListAsync(cancellationToken);
        return orders;
    }
}