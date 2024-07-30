using MediatR;
using Template.Application.Features.Recipe.Shared;
using Template.Application.Interfaces.Services;

namespace Template.Application.Features.Recipe.Queries
{
    public record class AddNewRecipeQuery(RecipeDto RecipeDto) : IRequest<RecipeDto>;

    internal class AddNewRecipeQueryHandler : IRequestHandler<AddNewRecipeQuery, RecipeDto>
    {
        private readonly IRecipeService _recipeService;

        public AddNewRecipeQueryHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<RecipeDto> Handle(AddNewRecipeQuery query, CancellationToken cancellationToken)
        {
            var recipeEntity = await _recipeService.AddNewRecipeAsync(query.RecipeDto);

            if (recipeEntity != null)
            {
                return RecipeMapper.ToRecipeDto(recipeEntity);
            }
            else
            {
                return null;
            }

        }
    }
}
