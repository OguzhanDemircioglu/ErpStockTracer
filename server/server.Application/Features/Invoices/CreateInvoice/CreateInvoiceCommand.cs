using MediatR;
using server.Domain.Dtos;
using TS.Result;

namespace server.Application.Features.Invoices.CreateInvoice;

public record CreateInvoiceCommand(
    Guid CustomerId,
    int InvoiceType,
    DateOnly OrderDate,
    string InvoiceNumber,
    List<InvoiceDetailDto> Details) : IRequest<Result<string>>;