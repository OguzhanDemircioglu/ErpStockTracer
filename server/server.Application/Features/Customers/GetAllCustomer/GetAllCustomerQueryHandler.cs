using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Customers.GetAllCustomer;

public sealed class GetAllCustomerQueryHandler (
    ICustomerRepository customerRepository): IRequestHandler<GetAllCustomerQuery, Result<List<Customer>>>
{
    public async Task<Result<List<Customer>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        List<Customer> customers = await customerRepository.GetAll().OrderBy(p => p.Name).ToListAsync(
            cancellationToken);

        return customers;
    }
}