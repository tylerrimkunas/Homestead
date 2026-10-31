using Homestead.Core.Aggregates.RecipeAggregate;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Homestead.App.UseCases.Recipes.List
{
    public enum FilterType
    {
        Contains,
        StartsWith,
        EndsWith,
        Equals,
        NotEquals,
        GreaterThan,
        LessThan,
        Between
    }
    public enum SortDirection
    {
        Ascending,
        Descending
    }
    public record RecipeListQuery
    {
        public int Start { get; set; } = 0;
        public int Length { get; set; } = 10;
        public ICollection<RecipeFilterNode> Filters { get; set; } = [];
        public ICollection<RecipeSortNode> Sorts { get; set; } = [];
    }
    public record RecipeFilterNode(string Property, FilterType Type, object Value, object? Value2 = null);
    public record RecipeSortNode(string Property, SortDirection Direction);
}
