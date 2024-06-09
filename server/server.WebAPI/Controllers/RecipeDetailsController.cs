using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Application.Features.RecipeDetails.DeleteRecipeDetailById;
using server.Application.Features.RecipeDetails.UpdateRecipeDetail;
using server.Application.Features.Recipes.GetByIdRecipeWithDetailsQuery;
using server.WebAPI.Abstractions;

namespace server.WebAPI.Controllers;

public sealed class RecipeDetailsController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> GetByIdRecipeWithDetails(GetByIdRecipeWithDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteRecipeDetailById(DeleteRecipeDetailByIdCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRecipeDetail(UpdateRecipeDetailCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }
}