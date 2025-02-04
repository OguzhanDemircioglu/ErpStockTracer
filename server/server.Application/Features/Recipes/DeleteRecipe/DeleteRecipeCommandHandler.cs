﻿using GenericRepository;
using MediatR;
using server.Domain.Entities;
using server.Domain.Repositories;
using TS.Result;

namespace server.Application.Features.Recipes.DeleteRecipe;

public class DeleteRecipeCommandHandler(
    IRecipeRepository respository,
    IUnitOfWork unitOfWork): IRequestHandler<DeleteRecipeByIdCommand, Result<string>>
{

    public async Task<Result<string>> Handle(DeleteRecipeByIdCommand command, CancellationToken cancellationToken)
    {
        Recipe product = await respository.GetByExpressionAsync(p => p.Id == command.Id, cancellationToken);

        if (product == null)
        {
            return Result<string>.Failure("Reçete bulunamadı");
        }
        
        respository.Delete(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Reçete Başarı ile Silindi";
    }
    
}