using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.Core.Aggregates.RecipeAggregate
{
    public class RecipeStep(int order, string directions)
    {
        public int RecipeId { get; set; }
        public int Order { get; set; } = order;
        public string Directions { get; set; } = directions;
        public Recipe Recipe { get; set; }
    }
}
