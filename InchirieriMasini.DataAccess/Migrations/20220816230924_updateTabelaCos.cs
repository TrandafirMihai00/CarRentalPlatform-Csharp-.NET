using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InchirieriMasini.DataAccess.Migrations
{
    public partial class updateTabelaCos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Cos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cos_ApplicationUserId",
                table: "Cos",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cos_AspNetUsers_ApplicationUserId",
                table: "Cos",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cos_AspNetUsers_ApplicationUserId",
                table: "Cos");

            migrationBuilder.DropIndex(
                name: "IX_Cos_ApplicationUserId",
                table: "Cos");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Cos");
        }
    }
}
