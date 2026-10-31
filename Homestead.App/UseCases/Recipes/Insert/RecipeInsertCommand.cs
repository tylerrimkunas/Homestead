using Homestead.App.UseCases.Recipes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.UseCases.Recipes.Insert
{
    public record RecipeInsertCommand : RecipeSaveContent
    {
        public required string Name { get; set; }
    }
}
