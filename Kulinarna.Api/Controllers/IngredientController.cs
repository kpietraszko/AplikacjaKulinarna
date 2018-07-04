using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kulinarna.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kulinarna.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IngredientController : ControllerBase
	{
		private readonly IIngredientService _ingredientService;

		public IngredientController(IIngredientService ingredientService)
		{
			_ingredientService = ingredientService;
		}
		// GET: api/Ingredient
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return this.HandleServiceResult(_ingredientService.GetAllIngredients());
		}
	}
}
