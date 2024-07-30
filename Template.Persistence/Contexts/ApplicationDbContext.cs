using Microsoft.EntityFrameworkCore;
using Template.Domain.Entities;

namespace Template.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<AccountRoleLinkEntity> AccountRoleLinks { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<RecipeIngredientLinkEntity> RecipeIngredientLinks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountRoleLinkEntity>()
                .HasKey(arl => new { arl.AccountId, arl.RoleId });

            modelBuilder.Entity<AccountRoleLinkEntity>()
                .HasOne(arl => arl.Account)
                .WithMany(a => a.RolesLink)
                .HasForeignKey(arl => arl.AccountId);

            modelBuilder.Entity<AccountRoleLinkEntity>()
                .HasOne(arl => arl.Role)
                .WithMany(r => r.AccountsLink)
                .HasForeignKey(arl => arl.RoleId);

            modelBuilder.Entity<RecipeIngredientLinkEntity>()
                .HasKey(ril => new { ril.RecipeId, ril.IngredientId });

            modelBuilder.Entity<RecipeIngredientLinkEntity>()
                .HasOne(ril => ril.Recipe)
                .WithMany(a => a.IngredientLinks)
                .HasForeignKey(ril => ril.RecipeId);

            modelBuilder.Entity<RecipeIngredientLinkEntity>()
                .HasOne(ril => ril.Ingredient)
                .WithMany(r => r.RecipeLinks)
                .HasForeignKey(ril => ril.IngredientId);
        }
    }
}