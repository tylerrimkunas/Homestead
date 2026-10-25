using Homestead.App.Data;
using Homestead.Core.Aggregates.RecipeAggregate;
using Homestead.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.Recipes.Insert
{
    internal class RecipeInsertHandler(HomesteadContextBase context) : ICommandAsyncHandler<RecipeInsertCommand, int>
    {
        public async Task<int> Handle(RecipeInsertCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name)) throw new ArgumentException("Name is required.");

            Recipe recipe;
            if (!string.IsNullOrWhiteSpace(command.Url))
            {
                recipe = new Recipe(command.Name, command.Url);
            }
            else if(command.ServingSize.HasValue && command.Steps.Count != 0 )
            {
                recipe = new Recipe(command.Name, command.ServingSize.Value);
                foreach (var step in command.Steps)
                {
                    recipe.Steps.Add(new RecipeStep(step.Order, step.Directions));
                }
                foreach(var ingredient in command.Ingredients)
                {
                    UnitOfMeasure unit = Enum.TryParse(ingredient.UnitOfMeasure, out unit) ? unit : UnitOfMeasure.None;
                    recipe.Ingredients.Add(new RecipeIngredient(ingredient.Ingredient, ingredient.AmountPerServing, unit));
                }
            }
            else throw new ArgumentException("Either Url or Serving Size and Steps must be provided.");
            context.Add(recipe);
            await context.SaveChangesAsync();
            return recipe.Id;
        }
    }
}
