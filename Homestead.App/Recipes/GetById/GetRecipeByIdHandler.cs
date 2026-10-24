using Homestead.App.Data;
using Homestead.App.Recipes.Dtos;

namespace Homestead.App.Recipes.GetById
{
    public class GetRecipeByIdHandler(HomesteadContextBase context) : IQueryHandler<GetRecipeByIdQuery, RecipeDto?>
    {
        RecipeDto? IQueryHandler<GetRecipeByIdQuery, RecipeDto?>.Query(GetRecipeByIdQuery query)
        {
            var recipe = context.Recipes.Find(query.Id);
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
