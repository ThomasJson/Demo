using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Common;

namespace Template.Domain.Entities
{
    public class RecipeEntity : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPeople { get; set; }
        public string RealizationTime { get; set; }

        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }
        public AccountEntity Account { get; set; }

        public ICollection<RecipeIngredientLinkEntity> IngredientLinks { get; set; }

    }

}