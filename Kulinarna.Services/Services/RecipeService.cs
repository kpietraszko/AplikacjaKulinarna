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
		public ServiceResult<int> AddRecipe(RecipeAddDTO recipeData)
		{
			var newRecipe = _mapper.Map<Recipe>(recipeData);
			newRecipe.RecipeIngredients = new List<RecipeIngredient>();
			_recipeRepository.Insert(newRecipe);
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
				_recipeRepository.Update(newRecipe); //potrzebne zeby zapisac zmiany w RecipeIngredients
			}
			return new ServiceResult<int>(newRecipe.Id);
		}

		public ServiceResult<RecipeDTO[]> GetAllRecipes()
		{
			var recipes = ((IIncludableQueryable<Recipe, object>)_recipeRepository.GetAll(r => r.RecipeIngredients)) //rzutowanie żeby mieć dostęp do ThenInclude
				.ThenInclude(ri => ((RecipeIngredient)ri).Ingredient); //rzutowanie bo object

			var mappedRecipes = _mapper.Map<RecipeDTO[]>(recipes);
			return new ServiceResult<RecipeDTO[]>(mappedRecipes);
		}
	}
}
