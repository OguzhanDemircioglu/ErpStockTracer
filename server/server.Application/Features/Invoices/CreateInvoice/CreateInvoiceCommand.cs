using MediatR;
using server.Domain.Dtos;
using TS.Result;

namespace server.Application.Features.Invoices.CreateInvoice;

public record CreateInvoiceCommand(
    Guid CustomerId,
    int TypeValue,
    DateOnly Date,
    string InvoiceNumber,
    List<InvoiceDetailDto> Details,
    Guid? OrderId) : IRequest<Result<string>>;