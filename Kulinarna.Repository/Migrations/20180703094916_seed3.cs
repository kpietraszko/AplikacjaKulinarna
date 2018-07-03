using Microsoft.EntityFrameworkCore.Migrations;

namespace Kulinarna.Repository.Migrations
{
    public partial class seed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "DifficultyRating", "DifficultyVotes", "Name", "QualityRating", "QualityVotes", "TimeToMake" },
                values: new object[] { 3, "Pokroić chleb w kromki i posmarować je masłem.", null, 0, "Chleb z masłem", null, 0, 3 });

            migrationBuilder.InsertData(
                table: "RecipesIngredients",
                columns: new[] { "RecipeId", "IngredientId", "Amount", "AmountUnit" },
                values: new object[] { 2, 5, 1m, 2 });

            migrationBuilder.InsertData(
                table: "RecipesIngredients",
                columns: new[] { "RecipeId", "IngredientId", "Amount", "AmountUnit" },
                values: new object[] { 2, 6, 20m, 0 });

            migrationBuilder.InsertData(
                table: "RecipesIngredients",
                columns: new[] { "RecipeId", "IngredientId", "Amount", "AmountUnit" },
                values: new object[] { 3, 3, 100m, 0 });

            migrationBuilder.InsertData(
                table: "RecipesIngredients",
                columns: new[] { "RecipeId", "IngredientId", "Amount", "AmountUnit" },
                values: new object[] { 3, 4, 30m, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
