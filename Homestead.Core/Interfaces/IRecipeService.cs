using Homestead.Core.RecipeAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.Core.Interfaces
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAll();
        Recipe? GetById(int id);
        int Insert(Recipe recipe);
        void Update(Recipe recipe);
        void Delete(int recipeId);
    }
}
