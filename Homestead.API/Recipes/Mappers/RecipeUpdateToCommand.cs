using Homestead.API.Recipes.Requests;
using Homestead.App.Recipes.Commands.Update;

namespace Homestead.API.Recipes.Mappers
{
    public static class RecipeUpdateToCommand
    {
        public static RecipeUpdateCommand ToCommand(this RecipeUpdateRequest request, int id)
        {
            var command = new RecipeUpdateCommand();
            return command;
        }
    }
}
