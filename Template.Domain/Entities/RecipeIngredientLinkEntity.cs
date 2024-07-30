using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities
{
    public class RecipeIngredientLinkEntity
    {
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public RecipeEntity Recipe { get; set; }

        [ForeignKey(nameof(Ingredient))]
        public int IngredientId { get; set; }
        public IngredientEntity Ingredient { get; set; }
        public string Quantity { get; set; }
    }
}
