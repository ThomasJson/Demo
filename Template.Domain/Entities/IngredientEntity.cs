using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Common;

namespace Template.Domain.Entities
{
    public class IngredientEntity : BaseAuditableEntity
    {
        public string Name { get; set; }
        public ICollection<RecipeIngredientLinkEntity> RecipeLinks { get; set; }
    }

}