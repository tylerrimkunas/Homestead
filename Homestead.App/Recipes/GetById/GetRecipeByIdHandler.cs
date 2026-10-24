using Homestead.App.Data;
using Homestead.App.Recipes.Dtos;

namespace Homestead.App.Recipes.GetById
{
    public class GetRecipeByIdHandler(HomesteadContextBase context) : IQueryAsyncHandler<GetRecipeByIdQuery, RecipeDto?>
    {
        async Task<RecipeDto?> IQueryAsyncHandler<GetRecipeByIdQuery, RecipeDto?>.Query(GetRecipeByIdQuery query)
        {
            var recipe = await context.Recipes.FindAsync(query.Id);
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
