using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.Donation7.Migrations
{
    /// <inheritdoc />
    public partial class Troca_Create_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trocas",
                columns: table => new
                {
                    TrocaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrocaStatus = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdutoIdMeu = table.Column<int>(type: "int", nullable: false),
                    ProdutoIdEscolhido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trocas", x => x.TrocaId);
                    table.ForeignKey(
                        name: "FK_Trocas_Produtos_ProdutoIdEscolhido",
                        column: x => x.ProdutoIdEscolhido,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Trocas_Produtos_ProdutoIdMeu",
                        column: x => x.ProdutoIdMeu,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trocas_ProdutoIdEscolhido",
                table: "Trocas",
                column: "ProdutoIdEscolhido");

            migrationBuilder.CreateIndex(
                name: "IX_Trocas_ProdutoIdMeu",
                table: "Trocas",
                column: "ProdutoIdMeu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trocas");
        }
    }
}
