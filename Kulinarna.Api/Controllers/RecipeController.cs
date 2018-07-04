using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public ActionResult<RecipeDTO[]> Get(int pageIndex = 0, int pageSize = 0) //pageIndex 0 to pierwsza strona
		{
			return this.HandleServiceResult(_recipeService.GetAllRecipes(pageIndex, pageSize));
		}

		// GET: api/Recipe/5
		[HttpGet("{id}")]
		public ActionResult<RecipeDTO> Get(int id)
		{
			return this.HandleServiceResult(_recipeService.GetRecipe(id));
		}

		// POST: api/Recipe
		[HttpPost]
		public ActionResult<int> Post(RecipeAddDTO recipeData)
		{
			if (recipeData.Ingredients.Length == 0)
			{
				ModelState.AddModelError("Ingredients", "At least 1 ingredient is required.");
				return new BadRequestObjectResult(ModelState);
			}
			return this.HandleServiceResult(_recipeService.AddRecipe(recipeData));
		}

		// PUT: api/Recipe/5
		[HttpPut("{id}")]
		public ActionResult<RecipeDTO> Put(int id, RecipeAddDTO recipeData)
		{
			return this.HandleServiceResult(_recipeService.EditRecipe(id, recipeData));
		}

		// DELETE: api/Recipe/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return this.HandleServiceResult(_recipeService.DeleteRecipe(id));
		}
		// POST: api/Recipe/Search
		[HttpPost("[action]")]
		public ActionResult<RecipeDTO[]> Search(RecipeSearchDTO searchData, int pageIndex = 0, int pageSize = 0)
		{
			return this.HandleServiceResult(_recipeService.SearchRecipes(searchData, pageIndex, pageSize));
		}
	}
}
