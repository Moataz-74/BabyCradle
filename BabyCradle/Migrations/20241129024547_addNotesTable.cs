using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabyCradle.Migrations
{
    /// <inheritdoc />
    public partial class addNotesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Vaccinations",
                newName: "NotificationTime");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vaccinations",
                newName: "VaccineName");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Medicines",
                newName: "NotificationTime");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Medicines",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Feeding",
                newName: "NotificationTime");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Feeding",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicineName",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Feeding",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoodType",
                table: "Feeding",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChildId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ChildId",
                table: "Notes",
                column: "ChildId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MedicineName",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Feeding");

            migrationBuilder.DropColumn(
                name: "FoodType",
                table: "Feeding");

            migrationBuilder.RenameColumn(
                name: "VaccineName",
                table: "Vaccinations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NotificationTime",
                table: "Vaccinations",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Medicines",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NotificationTime",
                table: "Medicines",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Feeding",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "NotificationTime",
                table: "Feeding",
                newName: "Time");
        }
    }
}
