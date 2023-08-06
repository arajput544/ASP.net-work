using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccineWithEF.Migrations
{
    /// <inheritdoc />
    public partial class IntialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosesAmount = table.Column<int>(type: "int", nullable: false),
                    DaysBetweenDoses = table.Column<int>(type: "int", nullable: false),
                    TotalDosesRec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccines");
        }
    }
}
