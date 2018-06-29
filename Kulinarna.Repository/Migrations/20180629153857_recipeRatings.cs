using Microsoft.EntityFrameworkCore.Migrations;

namespace Kulinarna.Repository.Migrations
{
    public partial class recipeRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DifficultyRating",
                table: "Recipe",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "QualityRating",
                table: "Recipe",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DifficultyRating",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "QualityRating",
                table: "Recipe");
        }
    }
}
