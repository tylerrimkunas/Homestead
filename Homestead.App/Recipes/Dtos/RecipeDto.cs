using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.Recipes.Dtos
{
    public record RecipeDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? ServingSize { get; set; }
        public string? Url { get; set; }
        public ICollection<RecipeIngredientDto> Ingredients { get; set; } = [];
        public ICollection<RecipeStepDto> Steps { get; set; } = [];
    }
    public record RecipeIngredientDto(string Ingredient, double AmountPerServing, string? UnitOfMeasure);

    public record RecipeStepDto(int Order, string Directions);
}
