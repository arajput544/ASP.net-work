using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccinePatientManagement.Migrations
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
                    DosesRequired = table.Column<int>(type: "int", nullable: false),
                    DaysBetweenDoses = table.Column<int>(type: "int", nullable: true),
                    TotalDosesRecieved = table.Column<int>(type: "int", nullable: false),
                    TotalDosesLeft = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoseId = table.Column<int>(type: "int", nullable: false),
                    FirstDose = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecondDose = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Vaccines_DoseId",
                        column: x => x.DoseId,
                        principalTable: "Vaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoseId",
                table: "Patients",
                column: "DoseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Vaccines");
        }
    }
}
