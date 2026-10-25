using Homestead.App.Data;
using Homestead.Core.Aggregates.RecipeAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.Recipes.Delete
{
    public class RecipeDeleteHandler(HomesteadContextBase context) : ICommandAsyncHandler<RecipeDeleteCommand>
    {
        public async Task Handle(RecipeDeleteCommand command)
        {
            var recipe = await context.FindAsync<Recipe>(command.Id);
            if (recipe != null)
            {
                context.Remove(recipe);
                await context.SaveChangesAsync();
            }
        }
    }
}
