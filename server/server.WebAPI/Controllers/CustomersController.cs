using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Application.Features.Customers.CreateCustomer;
using server.Application.Features.Customers.GetAllCustomer;
using server.WebAPI.Abstractions;

namespace server.WebAPI.Controllers;

public sealed class CustomersController : ApiController
{
    public CustomersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        
        return StatusCode(response.StatusCode, response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        
        return StatusCode(response.StatusCode, response);
    }
}