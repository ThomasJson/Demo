using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Features.Account.Shared.Dto;
using Template.Domain.Entities;

namespace Template.Application.Features.Recipe.Shared
{
    public static class RecipeMapper
    {
        public static RecipeEntity ToRecipeEntity(RecipeDto recipeDto)
        {
            var recipeEntity = new RecipeEntity()
            {
                Id = recipeDto.Id,
                Name = recipeDto.Name,
                Description = recipeDto.Description,
                NumberOfPeople = recipeDto.NumberOfPeople,
                RealizationTime = recipeDto.RealizationTime,
                IngredientLinks = recipeDto.Ingredients.Select(i => new RecipeIngredientLinkEntity
                {
                    Ingredient = new IngredientEntity
                    {
                        Name = i.Name
                    },
                    Quantity = i.Quantity
                }).ToList()
            };

            return recipeEntity;
        }

        public static RecipeDto ToRecipeDto(RecipeEntity recipeEntity)
        {
            var recipeDto = new RecipeDto()
            {
                Id = recipeEntity.Id,
                Name = recipeEntity.Name,
                Description = recipeEntity.Description,
                NumberOfPeople = recipeEntity.NumberOfPeople,
                RealizationTime = recipeEntity.RealizationTime
            };

            return recipeDto;
        }

        public static List<RecipeDto> ToRecipeDtoList(List<RecipeEntity> recipeEntityList)
        {
            List<RecipeDto> _recipeDtoList = new List<RecipeDto>();

            foreach (var recipeEntity in recipeEntityList)
            {
                var recipeDto = new RecipeDto()
                {
                    Id = recipeEntity.Id,
                    Name = recipeEntity.Name,
                    Description = recipeEntity.Description,
                    NumberOfPeople = recipeEntity.NumberOfPeople,
                    RealizationTime = recipeEntity.RealizationTime,
                    Ingredients = recipeEntity.IngredientLinks.Select(link => new IngredientDto
                    {
                        Name = link.Ingredient.Name,
                        Quantity = link.Quantity
                    }).ToList()
                };

                _recipeDtoList.Add(recipeDto);
            }
            

            return _recipeDtoList;
        }
    }
}
