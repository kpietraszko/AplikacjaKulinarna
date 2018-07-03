using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kulinarna.Data.DTOs
{
	public class RecipeSearchDTO
	{
		public string[] Ingredients { get; set; } = new string[0];
		public int? MaxTimeToMake { get; set; }
		[RegularExpression("^.{0}$|^[a-zA-ZąćęłńóśźżĄĘŁŃÓŚŹŻ ]{3,}$")] //0 lub >=3 znaki, walidację też na froncie zrobić
		public string RecipeName { get; set; }
	}
}
