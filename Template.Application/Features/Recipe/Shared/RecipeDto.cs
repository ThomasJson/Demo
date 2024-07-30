using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Features.Recipe.Shared
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPeople { get; set; }
        public string RealizationTime { get; set; }
        public int AccountId { get; set; }
        public List<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();
    }

}