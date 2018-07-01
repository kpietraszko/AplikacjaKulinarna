using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kulinarna.Data.DTOs
{
	public class RecipeAddDTO
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		public int? TimeToMake { get; set; }
		public IngredientAddDTO[] Ingredients { get; set; }
	}
}
