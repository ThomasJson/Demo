using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Features.Recipe.Shared;
using Template.Application.Interfaces.Services;
using Template.Domain.Entities;

namespace Template.Application.Features.Recipe.Queries
{
    public record class DeleteRecipeQuery(int RecipeId) : IRequest<bool>;

    internal class DeleteRecipeQueryHandler : IRequestHandler<DeleteRecipeQuery, bool>
    {
        private readonly IRecipeService _recipeService;

        public DeleteRecipeQueryHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<bool> Handle(DeleteRecipeQuery query, CancellationToken cancellationToken)
        {

            bool result = await _recipeService.DeleteRecipe(query.RecipeId);

            if (result)
            {
                return true;
            }

            return false;
        }
    }
}
