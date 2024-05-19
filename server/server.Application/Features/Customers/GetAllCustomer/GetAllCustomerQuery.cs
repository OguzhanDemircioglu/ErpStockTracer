using MediatR;
using server.Domain.Entities;
using TS.Result;

namespace server.Application.Features.Customers.GetAllCustomer;

public sealed record GetAllCustomerQuery() : IRequest<Result<List<Customer>>>;