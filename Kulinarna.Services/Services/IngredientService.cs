using Kulinarna.Data.Models;
using Kulinarna.Repository.Interfaces;
using Kulinarna.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kulinarna.Services.Services
{
	public class IngredientService : IIngredientService
	{
		private readonly IRepository<Ingredient> _ingredientRepository;

		public IngredientService(IRepository<Ingredient> ingredientRepository)
		{
			_ingredientRepository = ingredientRepository;
		}
		public Ingredient GetOrCreateIngredient(string name)
		{
			Ingredient ingredient;
			ingredient = _ingredientRepository.GetBy(i => i.Name.ToLower() == name.ToLower().Trim());
			if (ingredient != null)
			{
				return ingredient;
			}
			ingredient = new Ingredient(name.Trim());
			_ingredientRepository.Insert(ingredient);
			return ingredient;
		}
	}
}
