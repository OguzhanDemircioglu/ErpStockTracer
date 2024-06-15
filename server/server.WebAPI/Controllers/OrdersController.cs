using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Application.Features.Orders.CreateOrder;
using server.Application.Features.Orders.DeleteOrderById;
using server.Application.Features.Orders.GetAllOrder;
using server.Application.Features.Orders.UpdateOrder;
using server.WebAPI.Abstractions;

namespace server.WebAPI.Controllers;

public sealed class OrdersController : ApiController
{
  public OrdersController(IMediator mediator) : base(mediator)
  {
  }

  [HttpPost]
  public async Task<IActionResult> GetAll(GetAllOrderQuery request, CancellationToken cancellationToken)
  {
    var response = await _mediator.Send(request, cancellationToken);

    return StatusCode(response.StatusCode, response);
  }

  [HttpPost]
  public async Task<IActionResult> Create(CreateOrderCommand request, CancellationToken cancellationToken)
  {
    var response = await _mediator.Send(request, cancellationToken);

    return StatusCode(response.StatusCode, response);
  }

  [HttpPost]
  public async Task<IActionResult> DeleteById(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
  {
    var response = await _mediator.Send(request, cancellationToken);

    return StatusCode(response.StatusCode, response);
  }

  [HttpPost]
  public async Task<IActionResult> Update(UpdateOrderCommand request, CancellationToken cancellationToken)
  {
    var response = await _mediator.Send(request, cancellationToken);

    return StatusCode(response.StatusCode, response);
  }
}