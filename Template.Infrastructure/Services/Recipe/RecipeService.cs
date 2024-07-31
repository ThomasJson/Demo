using Azure.Core;
using Microsoft.Extensions.Logging;
using Template.Application.Features.Recipe.Shared;
using Template.Application.Interfaces.Services;
using Template.Domain.Entities;
using Template.Infrastructure.Services.Authentication;
using Template.Persistence.Repositories;

namespace Template.Infrastructure.Services.Recipe
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeRepository _recipeRepository;
        private readonly IngredientRepository _ingredientRepository;
        private readonly ILogger<AuthService> _logger;

        public RecipeService(RecipeRepository recipeRepository, IngredientRepository ingredientRepository, ILogger<AuthService> logger)
        {
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
            _logger = logger;
        }

        public async Task<List<RecipeEntity>> GetAllRecipesByAccountId(int id)
        {
            try
            {
                List<RecipeEntity> recipeEntities = await _recipeRepository.GetAllByAccountIdAsync(id);
                return recipeEntities;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the account recipes.", ex);
            }
            
        }

        public async Task<RecipeEntity> AddNewRecipe(RecipeDto recipeDto)
        {
            try
            {
                var ingredientLinks = new List<RecipeIngredientLinkEntity>();

                foreach (var ingredientDto in recipeDto.Ingredients)
                {
                    var ingredientEntity = await _ingredientRepository.GetByNameAsync(ingredientDto.Name);

                    if (ingredientEntity == null)
                    {
                        ingredientEntity = new IngredientEntity { Name = ingredientDto.Name };
                        ingredientEntity = await _ingredientRepository.AddAsync(ingredientEntity);
                    }

                    ingredientLinks.Add(new RecipeIngredientLinkEntity
                    {
                        IngredientId = ingredientEntity.Id,
                        Ingredient = ingredientEntity,
                        Quantity = ingredientDto.Quantity
                    });
                }

                var recipeEntity = new RecipeEntity
                {
                    Name = recipeDto.Name,
                    Description = recipeDto.Description,
                    NumberOfPeople = recipeDto.NumberOfPeople,
                    RealizationTime = recipeDto.RealizationTime.ToString(),
                    AccountId = recipeDto.AccountId,
                    IngredientLinks = ingredientLinks
                };

                return await _recipeRepository.AddAsync(recipeEntity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the new recipe.", ex);
            }
        }

        public async Task<bool> DeleteRecipe(int id)
        {
            try
            {
                return await _recipeRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting the selected recipe.", ex);
            }
        }

    }

}