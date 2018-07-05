using Kulinarna.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Services.Interfaces
{
	public interface IRecipeService
	{
		ServiceResult<int> AddRecipe(RecipeAddDTO recipeData);
		ServiceResult<RecipeDTO[]> GetAllRecipes(int pageIndex = 0, int pageSize = 0);
		ServiceResult<RecipeDTO> GetRecipe(int id);
		ServiceResult<RecipeDTO> EditRecipe(int id, RecipeAddDTO recipeData);
		ServiceResult DeleteRecipe(int id);
		ServiceResult<RecipeDTO[]> SearchRecipes(RecipeSearchDTO searchData, int pageIndex = 0, int pageSize = 0);
		ServiceResult<float> GetQualityRating(int id);
		ServiceResult<float> GetDifficultyRating(int id);
		ServiceResult AddQualityRating(int id, float rating);
		ServiceResult AddDifficultyRating(int id, float rating);
	}
}
