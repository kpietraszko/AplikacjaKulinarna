using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kulinarna.Data.Models
{
	public class Ingredient : ModelBase
	{
		[Required]
		public string Name { get; set; }
		public ICollection<RecipeIngredient> IngredientRecipes { get; set; }

		public Ingredient(string name)
		{
			Name = name;
		}
		public Ingredient()
		{

		}
		public override string ToString()
		{
			return Name;
		}
	}
}
