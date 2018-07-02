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
		public ActionResult<RecipeDTO> Get(int id)
		{
			return this.HandleServiceResult(_recipeService.GetRecipe(id));
		}

		// POST: api/Recipe
		[HttpPost]
		public ActionResult<int> Post(RecipeAddDTO recipeData)
		{
			return this.HandleServiceResult(_recipeService.AddRecipe(recipeData));
		}

		// PUT: api/Recipe/5
		[HttpPut("{id}")]
		public ActionResult<RecipeDTO> Put(int id, RecipeAddDTO recipeData)
		{
			return this.HandleServiceResult(_recipeService.EditRecipe(id, recipeData));
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return this.HandleServiceResult(_recipeService.DeleteRecipe(id));
		}
	}
}
