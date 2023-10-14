using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteDeQuadrinhos.Migrations
{
    public partial class AtualizacaoTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Quadrinhos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "usuarioModelId",
                table: "Quadrinhos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Quadrinhos_usuarioModelId",
                table: "Quadrinhos",
                column: "usuarioModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quadrinhos_Usuarios_usuarioModelId",
                table: "Quadrinhos",
                column: "usuarioModelId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quadrinhos_Usuarios_usuarioModelId",
                table: "Quadrinhos");

            migrationBuilder.DropIndex(
                name: "IX_Quadrinhos_usuarioModelId",
                table: "Quadrinhos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Quadrinhos");

            migrationBuilder.DropColumn(
                name: "usuarioModelId",
                table: "Quadrinhos");
        }
    }
}
