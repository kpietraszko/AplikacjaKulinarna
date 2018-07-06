using Microsoft.EntityFrameworkCore.Migrations;

namespace Kulinarna.Repository.Migrations
{
    public partial class ratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QualityVotes",
                table: "Recipes",
                newName: "NumberOfQualityRatings");

            migrationBuilder.RenameColumn(
                name: "DifficultyVotes",
                table: "Recipes",
                newName: "NumberOfDifficultyRatings");

            migrationBuilder.AlterColumn<float>(
                name: "QualityRating",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "DifficultyRating",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { 0f, 0f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfQualityRatings",
                table: "Recipes",
                newName: "QualityVotes");

            migrationBuilder.RenameColumn(
                name: "NumberOfDifficultyRatings",
                table: "Recipes",
                newName: "DifficultyVotes");

            migrationBuilder.AlterColumn<float>(
                name: "QualityRating",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<float>(
                name: "DifficultyRating",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DifficultyRating", "QualityRating" },
                values: new object[] { null, null });
        }
    }
}
