using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppCrudCore.Migrations
{
    /// <inheritdoc />
    public partial class TablacategoriayajustesdeLibroycliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Libro");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Libro",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdCategoria",
                table: "Libro",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaRegistro",
                table: "Cliente",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "IdCategoria", "Activo", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Literatura" },
                    { 2, true, "Ciencia" },
                    { 3, true, "Tecnología" },
                    { 4, true, "Historia" },
                    { 5, true, "Fantasía" },
                    { 6, true, "Ciencia Ficción" },
                    { 7, true, "Educación" },
                    { 8, true, "Infantil" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_CategoriaIdCategoria",
                table: "Libro",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Nombre",
                table: "Categoria",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Categoria_CategoriaIdCategoria",
                table: "Libro",
                column: "CategoriaIdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Categoria_CategoriaIdCategoria",
                table: "Libro");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Libro_CategoriaIdCategoria",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Libro");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Libro",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                table: "Cliente",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
