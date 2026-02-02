using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCrudCore.Migrations
{
    /// <inheritdoc />
    public partial class AssignDefaultRolToEmpleados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
    "UPDATE Empleado SET RolId = 2 WHERE RolId IS NULL OR RolId = 0"
);

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Rol_RolId",
                table: "Empleado");

            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "Empleado",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Rol_RolId",
                table: "Empleado",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Rol_RolId",
                table: "Empleado");

            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "Empleado",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Rol_RolId",
                table: "Empleado",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "IdRol");
        }
    }
}
