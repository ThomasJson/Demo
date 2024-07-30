using Template.Application.Features.Recipe.Shared;
using Template.Domain.Entities;

namespace Template.Application.Interfaces.Services
{
    public interface IRecipeService
    {
        Task<RecipeEntity> AddNewRecipeAsync(RecipeDto recipeDto);
        Task<List<RecipeEntity>> GetAllRecipesByAccountId(int id);
    }

}