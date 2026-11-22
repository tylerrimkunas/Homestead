using Homestead.App.Recipes.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.Recipes
{
    public abstract record RecipeSaveContent
    {
        public int? ServingSize { get; set; }
        public string? Url { get; set; }
        public ICollection<RecipeIngredientDto> Ingredients { get; set; } = [];
        public ICollection<RecipeStepDto> Steps { get; set; } = [];
    }
}
