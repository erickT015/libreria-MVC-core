using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCrudCore.Migrations
{
    /// <inheritdoc />
    public partial class CrearModelosclienteyLibro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    IdLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnioPublicacion = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Resumen = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StockTotal = table.Column<int>(type: "int", nullable: false),
                    StockDisponible = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.IdLibro);
                    table.CheckConstraint("CK_Libro_Stock", "StockDisponible <= StockTotal");
                    table.CheckConstraint("CK_Libro_Stock_NoNegativo", "StockTotal >= 0 AND StockDisponible >= 0");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Cedula",
                table: "Empleado",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Cedula",
                table: "Cliente",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_RolId",
                table: "Cliente",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_ISBN",
                table: "Libro",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_Titulo",
                table: "Libro",
                column: "Titulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_Cedula",
                table: "Empleado");
        }
    }
}
