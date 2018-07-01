using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kulinarna.Data.DTOs;
using Kulinarna.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kulinarna.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController] //isValid sprawdzane jest automatycznie i zwraca 400 //[FromBody] domyślne dla modeli klasowych
	public class RecipeController : ControllerBase
	{
		private readonly IRecipeService _recipeService;

		public RecipeController(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}
		// GET: api/Recipe
		[HttpGet]
		public ActionResult<RecipeDTO[]> Get()
		{
			return this.HandleServiceResult(_recipeService.GetAllRecipes());
		}

		// GET: api/Recipe/5
		[HttpGet("{id}", Name = "Get")]
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/Recipe
		[HttpPost]
		public ActionResult<int> Post(RecipeAddDTO recipe)
		{
			return this.HandleServiceResult(_recipeService.AddRecipe(recipe));
		}

		// PUT: api/Recipe/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
