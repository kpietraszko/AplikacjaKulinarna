using Kulinarna.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Data.DTOs
{
	public class RecipeIngredientDTO
	{
		public string Name { get; set; }
		public decimal Amount { get; set; }
		public int AmountUnit { get; set; }
	}
}
