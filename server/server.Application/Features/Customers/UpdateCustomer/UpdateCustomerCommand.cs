using MediatR;
using TS.Result;

namespace server.Application.Features.Customers.UpdateCustomer;

public sealed record UpdateCustomerCommand(
    Guid Id,
    string Name,
    string TaxDepartment,
    string TaxNumber,
    string City,
    string Town,
    string FullAdress
) : IRequest<Result<string>>;