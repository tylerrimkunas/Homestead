using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.Core.RecipeAggregate
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public Recipe Recipe { get; set; }
    }
}
