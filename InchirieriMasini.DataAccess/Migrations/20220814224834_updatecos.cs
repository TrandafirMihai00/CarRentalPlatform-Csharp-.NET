using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InchirieriMasini.DataAccess.Migrations
{
    public partial class updatecos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cos",
                columns: table => new
                {
                    IdCos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInceput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSfarsit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumarZile = table.Column<int>(type: "int", nullable: false),
                    TarifTotal = table.Column<double>(type: "float", nullable: false),
                    IdMasina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cos", x => x.IdCos);
                    table.ForeignKey(
                        name: "FK_Cos_Masini_IdMasina",
                        column: x => x.IdMasina,
                        principalTable: "Masini",
                        principalColumn: "IdMasina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cos_IdMasina",
                table: "Cos",
                column: "IdMasina");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cos");
        }
    }
}
