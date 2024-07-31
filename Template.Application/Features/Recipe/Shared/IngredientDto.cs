using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Features.Recipe.Shared
{
    public class IngredientDto
    {
        [Required(ErrorMessage = "Ingredient name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public string Quantity { get; set; }
    }

}