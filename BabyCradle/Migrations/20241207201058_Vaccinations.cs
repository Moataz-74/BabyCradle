using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BabyCradle.Migrations
{
    /// <inheritdoc />
    public partial class Vaccinations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RemainingTime",
                table: "Vaccinations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VaccinationTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntervalAfterBirth = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationTemplates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VaccinationTemplates",
                columns: new[] { "Id", "Information", "IntervalAfterBirth", "VaccineName" },
                values: new object[,]
                {
                    { 1, "Protects against Hepatitis B. First dose is given within 24 hours of birth.", 864000000000L, "Hepatitis B Vaccine (HBV)" },
                    { 2, "Protects against Diphtheria, Tetanus, and Pertussis.", 51840000000000L, "DTaP (Diphtheria, Tetanus, Pertussis)" },
                    { 3, "Protects against Polio.", 51840000000000L, "IPV (Inactivated Polio Vaccine)" },
                    { 4, "Protects against Haemophilus influenzae infections.", 51840000000000L, "Hib (Haemophilus Influenzae Type B)" },
                    { 5, "Protects against pneumococcal infections.", 51840000000000L, "PCV (Pneumococcal Conjugate Vaccine)" },
                    { 6, "Protects against Rotavirus.", 51840000000000L, "Rotavirus Vaccine" },
                    { 7, "Protects against Measles. First dose is given at 9 months.", 233280000000000L, "Measles Vaccine" },
                    { 8, "Protects against Measles, Mumps, and Rubella.", 315360000000000L, "MMR (Measles, Mumps, Rubella)" },
                    { 9, "Protects against Hepatitis A.", 315360000000000L, "Hepatitis A Vaccine" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationTemplates");

            migrationBuilder.DropColumn(
                name: "RemainingTime",
                table: "Vaccinations");
        }
    }
}
