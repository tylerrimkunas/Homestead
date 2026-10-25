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
        protected void Update(string? name)
        {
            if (!string.IsNullOrWhiteSpace(name)) this.Name = name;
        }
        public void Update(string? name, string url) 
        {
            Update(name);
            this.Url = url;

            this.DefaultServingSize = null;
            this.Ingredients = [];
            this.Steps = [];
        }
        public void Update(string? name, int? defaultServingSize, ICollection<RecipeIngredient> ingredients, ICollection<RecipeStep> steps)
        {
            Update(name);
            if(defaultServingSize.HasValue) this.DefaultServingSize = defaultServingSize.Value;
            if(ingredients != null) this.Ingredients = ingredients;
            if (steps != null) this.Steps = steps;

            this.Url = null;
        }
    }
}
