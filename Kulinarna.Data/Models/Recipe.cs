using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kulinarna.Data.Models
{
	public class Recipe : ModelBase
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		public int? TimeToMake { get; set; }
		public float QualityRating { get; set; }
		public int NumberOfQualityRatings { get; set; }
		public float DifficultyRating { get; set; }
		public int NumberOfDifficultyRatings { get; set; }
		public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
	}
}
