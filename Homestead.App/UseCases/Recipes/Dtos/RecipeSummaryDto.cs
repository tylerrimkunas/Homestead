using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.UseCases.Recipes.Dtos
{
    public record RecipeSummaryDto(int Id, string Name, int? ServingSize);
}
