using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteDeQuadrinhos.Migrations
{
    public partial class TabelasNovas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Documento = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    usuarioModelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autor_Usuarios_usuarioModelId",
                        column: x => x.usuarioModelId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Capitulo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuadrinhoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    quadrinhoModelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Capitulo_Quadrinhos_quadrinhoModelId",
                        column: x => x.quadrinhoModelId,
                        principalTable: "Quadrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pagina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Pagina = table.Column<byte[]>(type: "longblob", nullable: false),
                    CapituloId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    capituloModelId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagina_Capitulo_capituloModelId",
                        column: x => x.capituloModelId,
                        principalTable: "Capitulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Autor_usuarioModelId",
                table: "Autor",
                column: "usuarioModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Capitulo_quadrinhoModelId",
                table: "Capitulo",
                column: "quadrinhoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagina_capituloModelId",
                table: "Pagina",
                column: "capituloModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Pagina");

            migrationBuilder.DropTable(
                name: "Capitulo");
        }
    }
}
