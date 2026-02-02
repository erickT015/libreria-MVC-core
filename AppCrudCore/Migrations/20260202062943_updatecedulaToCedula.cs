using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCrudCore.Migrations
{
    /// <inheritdoc />
    public partial class updatecedulaToCedula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Rol_RolId",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "cedula",
                table: "Empleado",
                newName: "Cedula");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Rol_RolId",
                table: "Empleado",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Rol_RolId",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "Cedula",
                table: "Empleado",
                newName: "cedula");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Rol_RolId",
                table: "Empleado",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
