using Homestead.App.Data;
using Homestead.App.Recipes.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Homestead.App.Recipes.GetById
{
    public class RecipeGetByIdHandler(HomesteadContextBase context) : IQueryAsyncHandler<RecipeGetByIdQuery, RecipeDto?>
    {
        async Task<RecipeDto?> IQueryAsyncHandler<RecipeGetByIdQuery, RecipeDto?>.Query(RecipeGetByIdQuery query)
        {
            var recipe = await context.Recipes
                .Include(x => x.Ingredients)
                .Include(x => x.Steps)
                .FirstOrDefaultAsync(x => x.Id == query.Id);
            if (recipe == null)
            {
                return null;
            }
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                ServingSize = recipe.DefaultServingSize
            };
        }
    }
}
