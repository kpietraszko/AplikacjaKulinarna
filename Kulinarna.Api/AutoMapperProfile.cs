using AutoMapper;
using Kulinarna.Data.DTOs;
using Kulinarna.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kulinarna.Api
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<RecipeAddDTO, Recipe>();
			CreateMap<Recipe, RecipeDTO>()
				.ForMember(r => r.Ingredients, o => o.MapFrom( //wyglada na to ze dziala
					r => r.RecipeIngredients.Select(
						i => new RecipeIngredientDTO { Name = i.Ingredient.ToString(), Amount = i.Amount, AmountUnit = (int)i.AmountUnit })
					)
				);
		}
	}
}
