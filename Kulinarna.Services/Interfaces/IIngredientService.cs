using Kulinarna.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Services.Interfaces
{
	public interface IIngredientService
	{
		Ingredient GetOrCreateIngredient(string name);
	}
}
