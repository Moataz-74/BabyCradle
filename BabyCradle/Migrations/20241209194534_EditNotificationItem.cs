using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabyCradle.Migrations
{
    /// <inheritdoc />
    public partial class EditNotificationItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeding_Children_ChildId",
                table: "Feeding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feeding",
                table: "Feeding");

            migrationBuilder.RenameTable(
                name: "Feeding",
                newName: "Feedings");

            migrationBuilder.RenameIndex(
                name: "IX_Feeding_ChildId",
                table: "Feedings",
                newName: "IX_Feedings_ChildId");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Feedings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedings",
                table: "Feedings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedings_Children_ChildId",
                table: "Feedings",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedings_Children_ChildId",
                table: "Feedings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedings",
                table: "Feedings");

            migrationBuilder.RenameTable(
                name: "Feedings",
                newName: "Feeding");

            migrationBuilder.RenameIndex(
                name: "IX_Feedings_ChildId",
                table: "Feeding",
                newName: "IX_Feeding_ChildId");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Vaccinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Feeding",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feeding",
                table: "Feeding",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeding_Children_ChildId",
                table: "Feeding",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
