using Kulinarna.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Repository
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			//klucze główne
			builder.Entity<RecipeIngredient>()
				.HasKey(r => new { r.RecipeId, r.IngredientId });
			//seed
			builder.Entity<Ingredient>().HasData(
				new Ingredient("płatki śniadaniowe") { Id = 1 },
				new Ingredient("mleko") { Id = 2 },
				new Ingredient("chleb biały") {  Id = 3 },
				new Ingredient("masło") { Id = 4 },
				new Ingredient("woda") { Id = 5 },
				new Ingredient("lód") { Id = 6 },
				new Ingredient("czarna herbata") { Id = 7 },
				new Ingredient("cukier") { Id = 8 },
				new Ingredient("zupka chińska") { Id = 9},
				new Ingredient("kawa rozpuszczalna") { Id = 10 },
				new Ingredient("smalec") { Id = 11 },
				new Ingredient("konserwa turystyczna") { Id = 12 },
				new Ingredient("kaszanka") { Id = 13 },
				new Ingredient("parówka") { Id = 14 },
				new Ingredient("sól") { Id = 15 }
				);
			builder.Entity<Recipe>().HasData(
				new Recipe { Id = 1, Name = "Płatki z mlekiem", Description = "Płatki wsypać do miski i zalać mlekiem.", TimeToMake = 2 },
				new Recipe { Id = 2, Name = "Woda z lodem", Description = "Wsypać lód do szklanki i zalać wodą.", TimeToMake = 1 },
				new Recipe { Id = 3, Name = "Chleb z masłem", Description = "Pokroić chleb w kromki i posmarować je masłem.", TimeToMake = 3 },
				new Recipe { Id = 4, Name = "Herbata czarna z cukrem", Description = "Herbatę zaparzyć zgodnie z instrukcją na opakowaniu, posłodzić", TimeToMake = 5},
				new Recipe { Id = 5, Name = "Zupka chińska", Description = "Zawartość opakowania wsypać do miski i zalać wrzącą wodą. Przykryć i odczekać 5 min.", TimeToMake = 7},
				new Recipe { Id = 6, Name = "Kawa rozpuszczalna z mlekiem i cukrem", Description = "Kawę zalać wrzącą wodą, dodać mleko i cukier", TimeToMake = 5 },
				new Recipe { Id = 7, Name = "Konserwa z kaszanką", Description = "Rozgrzać smalec na patelni, wrzucić kaszankę i konserwę turystyczną. Oddać psu.", TimeToMake = 10 },
				new Recipe { Id = 8, Name = "Zupa parówkowa", Description = "Parówki zalać wrzątkiem. Przykryć i odczekać 5 min. Doprawić solą.", TimeToMake = 8 }
				);
			builder.Entity<RecipeIngredient>().HasData(
				new RecipeIngredient { RecipeId = 1, IngredientId = 1, Amount = 60, AmountUnit = IngredientAmountUnit.g },
				new RecipeIngredient { RecipeId = 1, IngredientId = 2, Amount = 1, AmountUnit = IngredientAmountUnit.glass},
				new RecipeIngredient { RecipeId = 2, IngredientId = 5, Amount = 1, AmountUnit = IngredientAmountUnit.glass },
				new RecipeIngredient { RecipeId = 2, IngredientId = 6, Amount = 20, AmountUnit = IngredientAmountUnit.g },
				new RecipeIngredient { RecipeId = 3, IngredientId = 3, Amount = 100, AmountUnit = IngredientAmountUnit.g },
				new RecipeIngredient { RecipeId = 3, IngredientId = 4, Amount = 30, AmountUnit = IngredientAmountUnit.g },
				new RecipeIngredient { RecipeId = 4, IngredientId = 5, Amount = 1, AmountUnit = IngredientAmountUnit.glass },
				new RecipeIngredient { RecipeId = 4, IngredientId = 7, Amount = 1, AmountUnit = IngredientAmountUnit.tsp },
				new RecipeIngredient { RecipeId = 4, IngredientId = 8, Amount = 1, AmountUnit = IngredientAmountUnit.tsp },
				new RecipeIngredient { RecipeId = 5, IngredientId = 5, Amount = 400, AmountUnit = IngredientAmountUnit.ml },
				new RecipeIngredient { RecipeId = 5, IngredientId = 9, Amount = 1, AmountUnit = IngredientAmountUnit.pc },
				new RecipeIngredient { RecipeId = 6, IngredientId = 5, Amount = 1, AmountUnit = IngredientAmountUnit.glass },
				new RecipeIngredient { RecipeId = 6, IngredientId = 10, Amount = 10, AmountUnit = IngredientAmountUnit.g },
				new RecipeIngredient { RecipeId = 6, IngredientId = 2, Amount = 20, AmountUnit = IngredientAmountUnit.ml },
				new RecipeIngredient { RecipeId = 6, IngredientId = 8, Amount = 1, AmountUnit = IngredientAmountUnit.tbsp },
				new RecipeIngredient { RecipeId = 7, IngredientId = 11, Amount = 1, AmountUnit = IngredientAmountUnit.tbsp },
				new RecipeIngredient { RecipeId = 7, IngredientId = 12, Amount = 200, AmountUnit = IngredientAmountUnit.g },
				new RecipeIngredient { RecipeId = 7, IngredientId = 13, Amount = 2, AmountUnit = IngredientAmountUnit.pc },
				new RecipeIngredient { RecipeId = 8, IngredientId = 5, Amount = 500, AmountUnit = IngredientAmountUnit.ml },
				new RecipeIngredient { RecipeId = 8, IngredientId = 14, Amount = 3, AmountUnit = IngredientAmountUnit.pc },
				new RecipeIngredient { RecipeId = 8, IngredientId = 15, Amount = 5, AmountUnit = IngredientAmountUnit.g }
				);
		}


		public DbSet<Recipe> Recipes { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<RecipeIngredient> RecipesIngredients { get; set; }
	}

}
