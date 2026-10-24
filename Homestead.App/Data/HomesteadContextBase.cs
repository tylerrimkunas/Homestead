using Homestead.Core.Aggregates.RecipeAggregate;
using Microsoft.EntityFrameworkCore;

namespace Homestead.App.Data
{
    public abstract class HomesteadContextBase(DbContextOptions<HomesteadContextBase> options) : DbContext(options)
    {
        public DbSet<Recipe> Recipes { get; set; }
    }
}
