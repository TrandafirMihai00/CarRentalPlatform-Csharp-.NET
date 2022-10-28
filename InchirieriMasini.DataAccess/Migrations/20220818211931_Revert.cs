using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InchirieriMasini.DataAccess.Migrations
{
    public partial class Revert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateConfidentiale");

            migrationBuilder.DropTable(
                name: "Clienti");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Judet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "DateConfidentiale",
                columns: table => new
                {
                    IdDate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    CNP = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Domiciliu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarCI = table.Column<int>(type: "int", nullable: false),
                    SerieCI = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_DateConfidentiale_ClientID",
                table: "DateConfidentiale",
                column: "ClientID",
                unique: true);
        }
    }
}
