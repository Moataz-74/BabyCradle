using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabyCradle.Migrations
{
    /// <inheritdoc />
    public partial class addContentAttributeToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Feeding",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Feeding");
        }
    }
}
