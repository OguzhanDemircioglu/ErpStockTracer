using MediatR;
using server.Domain.Entities;
using TS.Result;

namespace server.Application.Features.Invoices.GetAllInvoice;

public sealed record GetAllInvoiceQuery(
    int Type) : IRequest<List<Invoice>>, IRequest<Result<List<Invoice>>>;