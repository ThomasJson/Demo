using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Persistence.Contexts;

namespace Template.Persistence.Repositories
{
    public class IngredientRepository
    {
        private readonly ApplicationDbContext _context;

        public IngredientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IngredientEntity> GetByNameAsync(string name)
        {
            return await _context.Ingredients.SingleOrDefaultAsync(i => i.Name == name);
        }

        public async Task<IngredientEntity> AddAsync(IngredientEntity ingredientEntity)
        {
            var result = _context.Ingredients.Add(ingredientEntity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }

}