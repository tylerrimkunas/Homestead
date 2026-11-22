using Homestead.API.Recipes.Requests;
using Homestead.App.Recipes.Commands.Insert;

namespace Homestead.API.Recipes.Mappers
{
    public static class RecipeCreateToCommand
    {
        public static RecipeInsertCommand ToCommand(this RecipeCreateRequest request)
        {
            var command = new RecipeInsertCommand();
            return command;
        }
    }
}
