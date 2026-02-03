using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCrudCore.Migrations
{
    /// <inheritdoc />
    public partial class SoluciondeFkdetablalibro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Categoria_CategoriaIdCategoria",
                table: "Libro");

            migrationBuilder.AlterColumn<int>(
                name: "IdCategoria",
                table: "Libro",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Libro",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Categoria_CategoriaIdCategoria",
                table: "Libro",
                column: "CategoriaIdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Categoria_CategoriaIdCategoria",
                table: "Libro");

            migrationBuilder.AlterColumn<string>(
                name: "IdCategoria",
                table: "Libro",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Libro",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Categoria_CategoriaIdCategoria",
                table: "Libro",
                column: "CategoriaIdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria");
        }
    }
}
