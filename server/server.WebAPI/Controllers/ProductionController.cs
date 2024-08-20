using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Application.Features.Productions.CreateProduction;
using server.Application.Features.Productions.DeleteProduction;
using server.Application.Features.Productions.GetAllProductions;
using server.WebAPI.Abstractions;

namespace server.WebAPI.Controllers;

public sealed class ProductionController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllProductionsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductionCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteProductionByIdCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }
}