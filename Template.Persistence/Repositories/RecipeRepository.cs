using Template.Domain.Entities;
using Template.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Template.Persistence.Repositories
{
    public class RecipeRepository : IDisposable
    {
        private readonly ApplicationDbContext _context;

        public RecipeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RecipeEntity> AddAsync(RecipeEntity recipeEntity)
        {
            var result = _context.Recipes.Add(recipeEntity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<RecipeEntity>> GetAllByAccountIdAsync(int accountId)
        {
            return await _context.Recipes
            .Where(r => r.AccountId == accountId)
            .Include(r => r.IngredientLinks)
                .ThenInclude(link => link.Ingredient)
            .ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var recipeEntity = await _context.Recipes.FindAsync(id);
            if (recipeEntity == null)
            {
                return false;
            }

            _context.Recipes.Remove(recipeEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}