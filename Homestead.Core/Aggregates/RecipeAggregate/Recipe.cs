namespace Homestead.Core.Aggregates.RecipeAggregate
{
    public class Recipe
    {
        protected Recipe(string name)
        {
            this.Name = name;
        }
        public Recipe(string name, int defaultServingSize) : this(name)
        {
            this.DefaultServingSize = defaultServingSize;
        }
        public Recipe(string name, string url) : this(name)
        {
            this.Url = url;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DefaultServingSize { get; set; }
        public string? Url { get; set; }
        public ICollection<RecipeIngredient> Ingredients { get; set; } = [];
        public ICollection<RecipeStep> Steps { get; set; } = [];
    }
}
