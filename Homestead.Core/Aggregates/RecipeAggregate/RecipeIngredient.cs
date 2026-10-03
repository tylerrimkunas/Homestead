using Homestead.Core.Enums;

namespace Homestead.Core.Aggregates.RecipeAggregate
{
    public class RecipeIngredient(string ingredient, double amountPerServing, UnitOfMeasure? unitOfMeasure = null)
    {
        public int RecipeId { get; set; }
        public string Ingredient { get; set; } = ingredient;
        public double AmountPerServing { get; set; } = amountPerServing;
        public UnitOfMeasure? UnitOfMeasure { get; set; } = unitOfMeasure;
        public Recipe Recipe { get; set; }
    }
}
