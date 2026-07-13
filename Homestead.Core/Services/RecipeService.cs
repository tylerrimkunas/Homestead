using Homestead.Core.Interfaces;
using Homestead.Core.RecipeAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.Core.Services
{
    public class RecipeService(DbContext context) : IRecipeService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipeId"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void Delete(int recipeId)
        {
            var recipe = GetById(recipeId) ?? throw new KeyNotFoundException();
            context.Set<Recipe>().Remove(recipe);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Recipe> GetAll() => [.. context.Set<Recipe>().Include(r => r.Ingredients).Include(r => r.Steps)];
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Recipe? GetById(int id) => context.Set<Recipe>().Find(id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public int Insert(Recipe recipe)
        {
            context.Add(recipe);
            context.SaveChanges();
            return recipe.Id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        public void Update(Recipe recipe)
        {
            context.Update(recipe);
            context.SaveChanges();
        }
    }
}
