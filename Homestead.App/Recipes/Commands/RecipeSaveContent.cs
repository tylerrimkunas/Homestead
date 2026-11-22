using Homestead.App.Recipes.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.Recipes.Commands
{
    public abstract record RecipeSaveContent
    {
        public string Name { get; set; } = string.Empty;
        public int? ServingSize { get; set; }
        public string? Url { get; set; }
        public ICollection<RecipeIngredientDto> Ingredients { get; set; } = [];
        public ICollection<RecipeStepDto> Steps { get; set; } = [];
    }
}
