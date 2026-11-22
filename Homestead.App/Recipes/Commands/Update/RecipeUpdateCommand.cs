using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.Recipes.Commands.Update
{
    public record RecipeUpdateCommand : RecipeSaveContent
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
