using Kulinarna.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Data.DTOs
{
	public class IngredientAddDTO //unused
	{
		public string Name { get; set; }
		public decimal Amount { get; set; }
		public IngredientAmountUnit AmountUnit { get; set; }
	}
}
