namespace Homestead.Core.Aggregates.RecipeAggregate
{
    public class Recipe(string name, int defaultServingSize)
    {
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public int DefaultServingSize { get; set; } = defaultServingSize;
        public ICollection<RecipeIngredient> Ingredients { get; set; } = [];
        public ICollection<RecipeStep> Steps { get; set; } = [];
    }
}
