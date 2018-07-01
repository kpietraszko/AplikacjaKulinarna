using Kulinarna.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kulinarna.Data.DTOs
{
	public class RecipeDTO
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		public int? TimeToMake { get; set; }
		public float? QualityRating { get; set; }
		public float? DifficultyRating { get; set; }
		[JsonIgnore]
		public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
		public RecipeIngredientDTO[] Ingredients { get; set; }
	}
}
