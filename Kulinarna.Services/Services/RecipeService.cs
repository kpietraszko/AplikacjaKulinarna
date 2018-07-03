using AutoMapper;
using Kulinarna.Data.DTOs;
using Kulinarna.Data.Models;
using Kulinarna.Repository.Interfaces;
using Kulinarna.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kulinarna.Services.Services
{
	public class RecipeService : IRecipeService
	{
		private readonly IIngredientService _ingredientService;
		private readonly IRepository<Recipe> _recipeRepository;
		private readonly IRepository<RecipeIngredient> _recipeIngredientRepostiory;
		private readonly IMapper _mapper;

		public RecipeService(
			IIngredientService ingredientService,
			IRepository<Recipe> recipeRepository,
			IRepository<RecipeIngredient> recipeIngredientRepostiory,
			IMapper mapper)
		{
			_ingredientService = ingredientService;
			_recipeRepository = recipeRepository;
			_recipeIngredientRepostiory = recipeIngredientRepostiory;
			_mapper = mapper;
		}
		public ServiceResult<int> AddRecipe(RecipeAddDTO recipeData) //sprawdzic
		{
			var newRecipe = _mapper.Map<Recipe>(recipeData);
			_recipeRepository.Insert(newRecipe);
			newRecipe.RecipeIngredients = GetOrCreateIngredients(recipeData.Ingredients, newRecipe.Id);
			_recipeRepository.Update(newRecipe);
			return new ServiceResult<int>(newRecipe.Id);
		}
		public ServiceResult<RecipeDTO[]> GetAllRecipes(int pageIndex, int pageSize) //dziala z paginacją
		{
			var recipes = _recipeRepository.GetAll(
				r => r.RecipeIngredients, ri => ((RecipeIngredient)ri).Ingredient, pageIndex, pageSize);

			var mappedRecipes = _mapper.Map<RecipeDTO[]>(recipes);
			return new ServiceResult<RecipeDTO[]>(mappedRecipes);
		}

		public ServiceResult<RecipeDTO> GetRecipe(int id) //dziala
		{
			var recipe = _recipeRepository.GetBy(r => r.Id == id,
				r => r.RecipeIngredients, ri => ((RecipeIngredient)ri).Ingredient);
			var mappedRecipe = _mapper.Map<RecipeDTO>(recipe);
			return new ServiceResult<RecipeDTO>(mappedRecipe);
		}

		public ServiceResult<RecipeDTO> EditRecipe(int id, RecipeAddDTO recipeData)
		{
			var existingRecipe = _recipeRepository.GetBy(r => r.Id == id);
			if (existingRecipe == null)
			{
				return new ServiceResult<RecipeDTO>("Recipe doesn't exist");
			}
			existingRecipe.Name = recipeData.Name;
			existingRecipe.Description = recipeData.Description;
			existingRecipe.TimeToMake = recipeData.TimeToMake;
			existingRecipe.RecipeIngredients = GetOrCreateIngredients(recipeData.Ingredients, existingRecipe.Id);
			_recipeRepository.Update(existingRecipe);
			return new ServiceResult<RecipeDTO>(GetRecipe(existingRecipe.Id).SuccessResult);
		}
		private Recipe CreateRecipe(RecipeAddDTO recipeData)
		{
			var newRecipe = _mapper.Map<Recipe>(recipeData);
			newRecipe.RecipeIngredients = new List<RecipeIngredient>();
			foreach (var ingredientData in recipeData.Ingredients)
			{
				var ingredient = _ingredientService.GetOrCreateIngredient(ingredientData.Name);
				newRecipe.RecipeIngredients.Add(
					new RecipeIngredient
					{
						RecipeId = newRecipe.Id,
						IngredientId = ingredient.Id,
						Amount = ingredientData.Amount,
						AmountUnit = ingredientData.AmountUnit
					});
			}
			return newRecipe;
		}
		private List<RecipeIngredient> GetOrCreateIngredients(IngredientAddDTO[] ingredientsData, int recipeId)
		{
			var recipeIngredients = new List<RecipeIngredient>();
			var existingIngredients = _recipeIngredientRepostiory.GetAllBy(ri => ri.RecipeId == recipeId).ToArray();
			foreach (var recipeIngredient in existingIngredients)
			{
				_recipeIngredientRepostiory.Delete(recipeIngredient);
			}
			foreach (var ingredientData in ingredientsData)
			{
				var ingredient = _ingredientService.GetOrCreateIngredient(ingredientData.Name);
				recipeIngredients.Add(
					new RecipeIngredient
					{
						RecipeId = recipeId,
						IngredientId = ingredient.Id,
						Amount = ingredientData.Amount,
						AmountUnit = ingredientData.AmountUnit
					});
			}
			return recipeIngredients;
		}

		public ServiceResult DeleteRecipe(int id)
		{
			var recipe = _recipeRepository.GetBy(r => r.Id == id);
			if (recipe == null)
			{
				return new ServiceResult<RecipeDTO>("Recipe doesn't exist");
			}
			_recipeRepository.Delete(recipe);
			return new ServiceResult();
		}

		public ServiceResult<RecipeDTO[]> SearchRecipes(RecipeSearchDTO searchData, int pageIndex = 0, int pageSize = 0)
		{
			var recipes = _recipeRepository.GetAllBy(r => //MatchesSearchQuery(r, searchData),
				(String.IsNullOrWhiteSpace(searchData.RecipeName) || r.Name.ToLower().Contains(searchData.RecipeName.ToLower())) &&
				(searchData.MaxTimeToMake == null || r.TimeToMake == null || r.TimeToMake <= searchData.MaxTimeToMake) &&
				searchData.Ingredients.Select(i => i.ToLower().Trim()).Except(
					r.RecipeIngredients.Select(ri => ri.Ingredient.Name.ToLower()))
					.Count() == 0, //oddzielna funkcja nie działa, więc muszę tak
					r => r.RecipeIngredients, ri => ((RecipeIngredient) ri).Ingredient, pageIndex, pageSize);

			var mappedRecipes = _mapper.Map<RecipeDTO[]>(recipes);
			return new ServiceResult<RecipeDTO[]>(mappedRecipes);
		}
		//bool MatchesSearchQuery(Recipe recipe, RecipeSearchDTO searchQuery) //nie działa, NRE L155
		//{
		//	if (!String.IsNullOrWhiteSpace(searchQuery.RecipeName))
		//	{
		//		if (!recipe.Name.ToLower().Contains(searchQuery.RecipeName.ToLower()))
		//		{
		//			return false;
		//		}
		//	}
		//	if (searchQuery.MaxTimeToMake != null && recipe.TimeToMake != null
		//		&& recipe.TimeToMake > searchQuery.MaxTimeToMake)
		//	{
		//		return false;
		//	}
		//	var recipeIngredients = recipe.RecipeIngredients.Select(ri => ri.Ingredient.Name);
		//	foreach (var ingredient in searchQuery.Ingredients)
		//	{
		//		if (recipeIngredients.FirstOrDefault(ri => ri.ToLower() == ingredient.ToLower().Trim()) == null)
		//			return false; // .RecipeIngredients jest null, wyglada na to ze Include nie dziala? //stepując kod działa WTF
		//	}
		//	return true;

		//}
	}
}
