using Kulinarna.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Services.Interfaces
{
	public interface IRecipeService
	{
		ServiceResult<int> AddRecipe(RecipeAddDTO recipeData);
		ServiceResult<RecipeDTO[]> GetAllRecipes();
		ServiceResult<RecipeDTO> GetRecipe(int id);
		ServiceResult<RecipeDTO> EditRecipe(int id, RecipeAddDTO recipeData);
		ServiceResult DeleteRecipe(int id);
	}
}
