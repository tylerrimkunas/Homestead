using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.Core.RecipeAggregate
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<RecipeStep> Steps { get; set; }
    }
}
