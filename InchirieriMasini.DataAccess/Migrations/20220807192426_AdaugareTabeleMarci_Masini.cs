using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InchirieriMasini.DataAccess.Migrations
{
    public partial class AdaugareTabeleMarci_Masini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarciMasini",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireMarca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCrearii = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarciMasini", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "Masini",
                columns: table => new
                {
                    IdMasina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelMasina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagineMasina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnFabricatie = table.Column<int>(type: "int", nullable: false),
                    DisponibilitateMasina = table.Column<bool>(type: "bit", nullable: false),
                    NumarInmatriculare = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TipCombustibil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarUsi = table.Column<int>(type: "int", nullable: false),
                    TipCutieViteza = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    MasaTotala = table.Column<float>(type: "real", nullable: false),
                    TarifPeZi = table.Column<float>(type: "real", nullable: false),
                    TarifPeSaptamana = table.Column<float>(type: "real", nullable: false),
                    TarifPeLuna = table.Column<float>(type: "real", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masini", x => x.IdMasina);
                    table.ForeignKey(
                        name: "FK_Masini_MarciMasini_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "MarciMasini",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masini_IdMarca",
                table: "Masini",
                column: "IdMarca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Masini");

            migrationBuilder.DropTable(
                name: "MarciMasini");
        }
    }
}
