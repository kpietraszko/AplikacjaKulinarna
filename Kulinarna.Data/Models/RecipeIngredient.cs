using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kulinarna.Data.Models
{
	public enum IngredientAmountUnit
	{
		g,
		ml,
		glass,
		tsp,
		tbsp
	}
	public class RecipeIngredient
	{
		public int RecipeId { get; set; }
		public Recipe Recipe { get; set; }
		public int IngredientId { get; set; }
		public Ingredient Ingredient { get; set; }
		public decimal Amount { get; set; }
		public IngredientAmountUnit AmountUnit { get; set; }
	}
}
