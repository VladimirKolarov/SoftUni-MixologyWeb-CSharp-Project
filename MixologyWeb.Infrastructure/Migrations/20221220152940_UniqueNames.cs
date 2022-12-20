using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MixologyWeb.Infrastructure.Data.Migrations
{
    public partial class UniqueNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YearReleased",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Comments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Performers_Name",
                table: "Performers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_Name",
                table: "Measurements",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Name",
                table: "Ingredients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cocktails_Name",
                table: "Cocktails",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Performers_Name",
                table: "Performers");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_Name",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_Name",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Cocktails_Name",
                table: "Cocktails");

            migrationBuilder.DropColumn(
                name: "YearReleased",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Comments");
        }
    }
}
