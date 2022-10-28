using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InchirieriMasini.DataAccess.Migrations
{
    public partial class adaugareLocatii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdLocatie",
                table: "Cos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Locatii",
                columns: table => new
                {
                    IdLocatie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireLocatie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatii", x => x.IdLocatie);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cos_IdLocatie",
                table: "Cos",
                column: "IdLocatie");

            migrationBuilder.AddForeignKey(
                name: "FK_Cos_Locatii_IdLocatie",
                table: "Cos",
                column: "IdLocatie",
                principalTable: "Locatii",
                principalColumn: "IdLocatie",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cos_Locatii_IdLocatie",
                table: "Cos");

            migrationBuilder.DropTable(
                name: "Locatii");

            migrationBuilder.DropIndex(
                name: "IX_Cos_IdLocatie",
                table: "Cos");

            migrationBuilder.DropColumn(
                name: "IdLocatie",
                table: "Cos");
        }
    }
}
