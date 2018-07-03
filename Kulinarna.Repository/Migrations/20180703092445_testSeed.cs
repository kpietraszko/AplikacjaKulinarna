using Microsoft.EntityFrameworkCore.Migrations;

namespace Kulinarna.Repository.Migrations
{
    public partial class testSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DifficultyVotes",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QualityVotes",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "płatki śniadaniowe" },
                    { 2, "mleko" },
                    { 3, "chleb biały" },
                    { 4, "masło" },
                    { 5, "woda" },
                    { 6, "lód" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "DifficultyRating", "DifficultyVotes", "Name", "QualityRating", "QualityVotes", "TimeToMake" },
                values: new object[,]
                {
                    { 1, "Płatki wsypać do miski i zalać mlekiem.", null, 0, "Płatki z mlekiem", null, 0, 2 },
                    { 2, "Wsypać lód do szklanki i zalać wodą.", null, 0, "Woda z lodem", null, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "RecipesIngredients",
                columns: new[] { "RecipeId", "IngredientId", "Amount", "AmountUnit" },
                values: new object[] { 1, 1, 60m, 0 });

            migrationBuilder.InsertData(
                table: "RecipesIngredients",
                columns: new[] { "RecipeId", "IngredientId", "Amount", "AmountUnit" },
                values: new object[] { 1, 2, 1m, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RecipesIngredients",
                keyColumns: new[] { "RecipeId", "IngredientId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "DifficultyVotes",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "QualityVotes",
                table: "Recipes");
        }
    }
}
