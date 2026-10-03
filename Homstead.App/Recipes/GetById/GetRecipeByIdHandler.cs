using Homstead.App.Data;
using Homstead.App.Recipes.Dtos;

namespace Homstead.App.Recipes.GetById
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
