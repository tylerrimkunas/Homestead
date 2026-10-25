using Homestead.Core.Aggregates.RecipeAggregate;
using Homestead.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.Recipes.Update
{
    public class RecipeUpdateHandler(HomesteadContextBase context) : ICommandAsyncHandler<RecipeUpdateCommand>
    {
        public async Task Handle(RecipeUpdateCommand command)
        {
            var recipe = await context.Recipes
                .Include(x => x.Ingredients)
                .Include(x => x.Steps)
                .FirstOrDefaultAsync(x => x.Id == command.Id) ?? throw new InvalidOperationException("Recipe not found");
            if(!string.IsNullOrWhiteSpace(command.Url))
            {
                recipe.Update(command.Name, command.Url);
            }
            else
            {
                recipe.Update(command.Name
                    , command.ServingSize
                    , [.. command.Ingredients.Select(i => new RecipeIngredient(i.Ingredient, i.AmountPerServing, Enum.TryParse(i.UnitOfMeasure, out UnitOfMeasure unit) ? unit : UnitOfMeasure.None))]
                    , [.. command.Steps.Select(s => new RecipeStep(s.Order, s.Directions))]);
            }
            await context.SaveChangesAsync();
        }
    }
}
