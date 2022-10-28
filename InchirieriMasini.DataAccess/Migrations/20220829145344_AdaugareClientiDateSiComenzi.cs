using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InchirieriMasini.DataAccess.Migrations
{
    public partial class AdaugareClientiDateSiComenzi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Judet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clienti_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    IdComanda = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMasina = table.Column<int>(type: "int", nullable: false),
                    DataInceput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSfarsit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    TarifPeZi = table.Column<double>(type: "float", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DataComanda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalComanda = table.Column<double>(type: "float", nullable: false),
                    StatusPlata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSesiune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdIntentiePlata = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.IdComanda);
                    table.ForeignKey(
                        name: "FK_Comenzi_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Comenzi_Clienti_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clienti",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comenzi_Masini_IdMasina",
                        column: x => x.IdMasina,
                        principalTable: "Masini",
                        principalColumn: "IdMasina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DateConfidentiale",
                columns: table => new
                {
                    IdDate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNP = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    SerieCI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarCI = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateConfidentiale", x => x.IdDate);
                    table.ForeignKey(
                        name: "FK_DateConfidentiale_Clienti_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clienti",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clienti_ApplicationUserId",
                table: "Clienti",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_ApplicationUserId",
                table: "Comenzi",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_ClientId",
                table: "Comenzi",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_IdMasina",
                table: "Comenzi",
                column: "IdMasina");

            migrationBuilder.CreateIndex(
                name: "IX_DateConfidentiale_ClientID",
                table: "DateConfidentiale",
                column: "ClientID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.DropTable(
                name: "DateConfidentiale");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
