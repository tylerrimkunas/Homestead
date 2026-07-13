using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.Core.RecipeAggregate
{
    public class RecipeStep
    {
        public int RecipeId { get; set; }
        public int Order { get; set; }
        public string Step { get; set; }
    }
}
