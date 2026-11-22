using Homestead.API.Recipes.Mappers;
using Homestead.API.Recipes.Requests;
using Homestead.App.Interfaces;
using Homestead.App.Recipes.Commands.Delete;
using Homestead.App.Recipes.Commands.Insert;
using Homestead.App.Recipes.Commands.Update;
using Homestead.App.Recipes.Dtos;
using Homestead.App.Recipes.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homestead.API.Recipes.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController(IQueryAsyncHandler<RecipeGetByIdQuery, RecipeDto?> getByIdhandler
        , ICommandAsyncHandler<RecipeInsertCommand, int> insertHandler
        , ICommandAsyncHandler<RecipeUpdateCommand> updateHandler
        , ICommandAsyncHandler<RecipeDeleteCommand> deleteHandler) : ControllerBase
    {
        [AcceptVerbs("QUERY")]
        public IEnumerable<string> Query()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto?>> Get(int id)
        {
            var query = new RecipeGetByIdQuery(id);
            var recipe = await getByIdhandler.Query(query);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        // POST api/<RecipesController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] RecipeCreateRequest body)
        {
            var command = body.ToCommand();
            var id = await insertHandler.Handle(command);
            return Ok(id);
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RecipeUpdateRequest value)
        {
            var command = value.ToCommand(id);
            await updateHandler.Handle(command);
            return Ok();
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new RecipeDeleteCommand(id);
            await deleteHandler.Handle(command);
            return Ok();
        }
    }
}
