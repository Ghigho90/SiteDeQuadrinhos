using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteDeQuadrinhos.Migrations
{
    public partial class ChangeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Autor_Documento",
                table: "Autor",
                column: "Documento",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Autor_Documento",
                table: "Autor");
        }
    }
}
