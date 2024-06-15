using MediatR;
using TS.Result;

namespace server.Application.Features.Customers.DeleteCustomer;

public sealed record DeleteCustomerByIdCommand(
    Guid Id) : IRequest<Result<string>>;