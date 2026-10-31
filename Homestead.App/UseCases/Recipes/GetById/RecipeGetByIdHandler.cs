using Homestead.App.Data;
using Homestead.App.UseCases.Recipes.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Homestead.App.UseCases.Recipes.GetById
{
    public class RecipeGetByIdHandler(HomesteadContextBase context) : IQueryAsyncHandler<RecipeGetByIdQuery, RecipeDto?>
    {
        async Task<RecipeDto?> IQueryAsyncHandler<RecipeGetByIdQuery, RecipeDto?>.Query(RecipeGetByIdQuery query)
        {
            var recipe = await context.Recipes
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.DefaultServingSize,
                    x.Url,
                    Ingredients = x.Ingredients.Select(i => new { i.Ingredient, i.AmountPerServing, i.UnitOfMeasure }),
                    Steps = x.Steps.Select(s => new { s.Order, s.Directions })
                })
                .FirstOrDefaultAsync(x => x.Id == query.Id);
            return recipe == null ? null : new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                ServingSize = recipe.DefaultServingSize,
                Url = recipe.Url,
                Ingredients = [.. recipe.Ingredients.Select(i => new RecipeIngredientDto(i.Ingredient, i.AmountPerServing, i.UnitOfMeasure?.ToString()))],
                Steps = [.. recipe.Steps.Select(s => new RecipeStepDto(s.Order, s.Directions))]
            };
        }
    }
}
