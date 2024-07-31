using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Features.Recipe.Shared
{
    public class RecipeDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Recipe name is required")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Number of people is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of people must be at least 1")]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "Realization time is required")]
        public string RealizationTime { get; set; }

        public int AccountId { get; set; }
        public List<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();
    }

}