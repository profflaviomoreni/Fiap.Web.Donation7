using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Web.Donation7.Migrations
{
    /// <inheritdoc />
    public partial class Categoria_Create_Index_Nome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categorias_NomeCategoria",
                table: "Categorias",
                column: "NomeCategoria",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categorias_NomeCategoria",
                table: "Categorias");
        }
    }
}
