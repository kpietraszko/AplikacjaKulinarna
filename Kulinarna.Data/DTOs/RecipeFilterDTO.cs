using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kulinarna.Data.DTOs
{
	public class RecipeFilterDTO
	{
		[Range(0.0, float.MaxValue)]
		public float? MinQualityRating { get; set; }
		[Range(0.0, float.MaxValue)]
		public float? MaxDifficultyRating { get; set; }
		[Range(0, int.MaxValue)]
		public int? MaxTimeToMake { get; set; }
	}
}
