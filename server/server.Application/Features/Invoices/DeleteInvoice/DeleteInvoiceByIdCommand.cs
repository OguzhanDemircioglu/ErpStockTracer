using MediatR;
using TS.Result;

namespace server.Application.Features.Invoices.DeleteInvoice;

public sealed record DeleteInvoiceByIdCommand(
    Guid Id) : IRequest<Result<string>>;