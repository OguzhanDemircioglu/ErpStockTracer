using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Application.Features.Recipes.CreateRecipe;
using server.Application.Features.Recipes.DeleteRecipe;
using server.Application.Features.Recipes.GetAllRecipe;
using server.WebAPI.Abstractions;

namespace server.WebAPI.Controllers;

public sealed class RecipeController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllRecipeQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteRecipeByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }
}