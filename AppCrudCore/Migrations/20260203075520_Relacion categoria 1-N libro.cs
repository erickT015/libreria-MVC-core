using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCrudCore.Migrations
{
    /// <inheritdoc />
    public partial class Relacioncategoria1Nlibro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Categoria_CategoriaIdCategoria",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_CategoriaIdCategoria",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Libro");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "Libro",
                newName: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_CategoriaId",
                table: "Libro",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Categoria_CategoriaId",
                table: "Libro",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Categoria_CategoriaId",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_CategoriaId",
                table: "Libro");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Libro",
                newName: "IdCategoria");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Libro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_CategoriaIdCategoria",
                table: "Libro",
                column: "CategoriaIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Categoria_CategoriaIdCategoria",
                table: "Libro",
                column: "CategoriaIdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
