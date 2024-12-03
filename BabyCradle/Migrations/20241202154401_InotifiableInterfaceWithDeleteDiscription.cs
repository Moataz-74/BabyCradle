using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabyCradle.Migrations
{
    /// <inheritdoc />
    public partial class InotifiableInterfaceWithDeleteDiscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Feeding");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Feeding",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
