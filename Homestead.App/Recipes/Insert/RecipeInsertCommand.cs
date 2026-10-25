using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.Recipes.Insert
{
    public record RecipeInsertCommand : RecipeSaveContent
    {
        public required string Name { get; set; }
    }
}
