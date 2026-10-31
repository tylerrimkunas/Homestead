using Homestead.App.UseCases.Recipes.Dtos;
using Homestead.Core.Aggregates.RecipeAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.UseCases.Recipes.List
{
    public class RecipeListHandler(HomesteadContextBase context) : IQueryAsyncHandler<RecipeListQuery, ListResult<RecipeSummaryDto>>
    {
        private readonly HomesteadContextBase context = context;

        public async Task<ListResult<RecipeSummaryDto>> Query(RecipeListQuery query)
        {
            var errors = new List<string>();
            var queryable = context.Recipes.AsQueryable();
            foreach (var filter in query.Filters)
            {
                try
                {
                    queryable = filter.Type switch
                    {
                        FilterType.Contains => queryable.Where(x => EF.Functions.Like(EF.Property<string>(x, filter.Property), $"%{filter.Value}%")),
                        FilterType.StartsWith => queryable.Where(x => EF.Functions.Like(EF.Property<string>(x, filter.Property), $"{filter.Value}%")),
                        FilterType.EndsWith => queryable.Where(x => EF.Functions.Like(EF.Property<string>(x, filter.Property), $"%{filter.Value}")),
                        FilterType.Equals => queryable.Where(x => EF.Property<object>(x, filter.Property) == filter.Value),
                        FilterType.NotEquals => queryable.Where(x => EF.Property<object>(x, filter.Property) != filter.Value),
                        FilterType.GreaterThan => queryable.Where(x => EF.Property<IComparable>(x, filter.Property).CompareTo(filter.Value) > 0),
                        FilterType.LessThan => queryable.Where(x => EF.Property<IComparable>(x, filter.Property).CompareTo(filter.Value) < 0),
                        FilterType.Between => queryable.Where(x => EF.Property<IComparable>(x, filter.Property).CompareTo(filter.Value) >= 0 && EF.Property<IComparable>(x, filter.Property).CompareTo(filter.Value2) <= 0),
                        _ => throw new NotImplementedException($"Filter type {filter.Type} is not implemented.")
                    };
                }
                catch (Exception ex)
                {
                    errors.Add($"Error applying filter on property {filter.Property}: {ex.Message}");
                }
            }
            var filtered = await queryable.CountAsync();
            foreach (var sort in query.Sorts)
            {
                try
                {
                    queryable = sort.Direction switch
                    {
                        SortDirection.Ascending => queryable is IOrderedQueryable<Recipe> orderQueryable ? orderQueryable.ThenBy(x => EF.Property<object>(x, sort.Property)) : queryable.OrderBy(x => EF.Property<object>(x, sort.Property)),
                        SortDirection.Descending => queryable is IOrderedQueryable<Recipe> orderQueryable ? orderQueryable.ThenByDescending(x => EF.Property<object>(x, sort.Property)) : queryable.OrderByDescending(x => EF.Property<object>(x, sort.Property)),
                        _ => throw new NotImplementedException($"Sort direction {sort.Direction} is not implemented.")
                    };
                }
                catch (Exception ex)
                {
                    errors.Add($"Error applying sort on property {sort.Property}: {ex.Message}");
                }
            }
            if (query.Length > 0)
                queryable = queryable.Skip(query.Start).Take(query.Length);
            var data = await queryable
                .Select(x => new RecipeSummaryDto(x.Id, x.Name, x.DefaultServingSize))
                .ToListAsync();
            return new ListResult<RecipeSummaryDto>()
            {
                Total = await context.Recipes.CountAsync(),
                Data = data,
                Filtered = filtered,
                Errors = errors
            };
        }
    }
}