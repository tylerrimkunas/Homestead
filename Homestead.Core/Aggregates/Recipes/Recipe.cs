using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.Core.Aggregates.Recipes
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeStep> Steps { get; set; } = [];
    }
}
