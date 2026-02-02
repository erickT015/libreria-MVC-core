using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppCrudCore.Migrations
{
    /// <inheritdoc />
    public partial class AddRolAndRolIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Empleado",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cedula",
                table: "Empleado",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "IdRol", "Activo", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Control completo del sistema", "Admin" },
                    { 2, true, "Gestión de libros y clientes", "Empleado" },
                    { 3, true, "Rol lógico para filtro y sin acceso por el momento", "Cliente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_RolId",
                table: "Empleado",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Nombre",
                table: "Rol",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Rol_RolId",
                table: "Empleado",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Rol_RolId",
                table: "Empleado");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_RolId",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "cedula",
                table: "Empleado");
        }
    }
}
