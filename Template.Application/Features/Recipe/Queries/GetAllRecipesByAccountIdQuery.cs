using MediatR;
using Template.Application.Features.Recipe.Shared;
using Template.Application.Interfaces.Services;
using Template.Domain.Entities;

namespace Template.Application.Features.Recipe.Queries
{
    public record class GetAllRecipesByAccountIdQuery(int AccountId) : IRequest<List<RecipeDto>>;

    internal class GetAllRecipesByAccountIdQueryHandler : IRequestHandler<GetAllRecipesByAccountIdQuery, List<RecipeDto>>
    {
        private readonly IRecipeService _recipeService;

        public GetAllRecipesByAccountIdQueryHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<List<RecipeDto>> Handle(GetAllRecipesByAccountIdQuery query, CancellationToken cancellationToken)
        {
            List<RecipeEntity> recipeEntityList = await _recipeService.GetAllRecipesByAccountId(query.AccountId);

            if (recipeEntityList != null)
            {
                return RecipeMapper.ToRecipeDtoList(recipeEntityList);
            }
            else
            {
                return null;
            }

        }
    }
}
