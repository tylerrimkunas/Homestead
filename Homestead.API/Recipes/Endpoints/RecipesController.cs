using Homestead.App.Interfaces;
using Homestead.App.Recipes.Dtos;
using Homestead.App.Recipes.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Homestead.API.Recipes.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController(IQueryAsyncHandler<RecipeGetByIdQuery, RecipeDto?> getByIdhandler) : ControllerBase
    {
        // GET: api/<RecipesController>
        [HttpGet]
        public IEnumerable<string> Get()
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
