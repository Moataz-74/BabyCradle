using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabyCradle.Migrations
{
    /// <inheritdoc />
    public partial class editFeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodType",
                table: "Feeding");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FoodType",
                table: "Feeding",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
