using Microsoft.EntityFrameworkCore.Migrations;

namespace Kulinarna.Repository.Migrations
{
    public partial class seed4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "czarna herbata" },
                    { 8, "cukier" },
                    { 9, "zupka chińska" },
                    { 10, "kawa rozpuszczalna" },
                    { 11, "smalec" },
                    { 12, "konserwa turystyczna" },
                    { 13, "kaszanka" },
                    { 14, "parówka" },
                    { 15, "sól" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "DifficultyRating", "DifficultyVotes", "Name", "QualityRating", "QualityVotes", "TimeToMake" },
                values: new object[,]
                {
                    { 4, "Herbatę zaparzyć zgodnie z instrukcją na opakowaniu, posłodzić", null, 0, "Herbata czarna z cukrem", null, 0, 5 },
                    { 5, "Zawartość opakowania wsypać do miski i zalać wrzącą wodą. Przykryć i odczekać 5 min.", null, 0, "Zupka chińska", null, 0, 7 },
                    { 6, "Kawę zalać wrzącą wodą, dodać mleko i cukier", null, 0, "Kawa rozpuszczalna z mlekiem i cukrem", null, 0, 5 },
                    { 7, "Rozgrzać smalec na patelni, wrzucić kaszankę i konserwę turystyczną. Oddać psu.", null, 0, "Konserwa z kaszanką", null, 0, 10 },
                    { 8, "Parówki zalać wrzątkiem. Przykryć i odczekać 5 min. Doprawić solą.", null, 0, "Zupa parówkowa", null, 0, 8 }
                });

            migrationBuilder.InsertData(
                table: "RecipesIngredients",
                columns: new[] { "RecipeId", "IngredientId", "Amount", "AmountUnit" },
                values: new object[,]
                {
                    { 4, 5, 1m, 2 },
                    { 4, 7, 1m, 3 },
                    { 4, 8, 1m, 3 },
                    { 5, 5, 400m, 1 },
                    { 5, 9, 1m, 5 },
                    { 6, 5, 1m, 2 },
                    { 6, 10, 10m, 0 },
                    { 6, 2, 20m, 1 },
                    { 6, 8, 1m, 4 },
                    { 7, 11, 1m, 4 },
                    { 7, 12, 200m, 0 },
                    { 7, 13, 2m, 5 },
                    { 8, 5, 500m, 1 },
                    { 8, 14, 3m, 5 },
                    { 8, 15, 5m, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 7, 11 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 7, 12 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 7, 13 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 8, 14 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 8, 15 });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
