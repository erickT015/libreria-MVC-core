using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using AppCrudCore.Models;

namespace AppCrudCore.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options)
        {
            
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Rol> Rol { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //prpiedades para tabla empleaos
            modelBuilder.Entity<Empleado>(tb =>
            {
                //propiedades para columna "col" idEmpleado
                tb.HasKey(col => col.IdEmpleado); //es primary
                tb.Property(col => col.IdEmpleado)
                .UseIdentityColumn() //incremental (1,1)
                .ValueGeneratedOnAdd(); //no envies valor, la db lo gesyiona

                tb.Property(col => col.Cedula)
                .IsRequired()
                .HasMaxLength(20);

                tb.Property(col => col.NombreCompleto).HasMaxLength(50);

                tb.Property(col => col.Correo).HasMaxLength(50);

                tb.Property(col => col.PasswordHash)
                .IsRequired() //no nulo
                .HasMaxLength(255); //tamaño de 255

                tb.HasOne(col => col.Rol)
                .WithMany() //se relacinoa con muchos
                .HasForeignKey(col => col.RolId);
            });

            modelBuilder.Entity<Empleado>().ToTable("Empleado"); //le asignamos el nombre, a la fuerza no por convencion

            //prpiedades para tabla Rol
            modelBuilder.Entity<Rol>(tb =>
            {
                //propiedades para columna "col" IdRol
                tb.HasKey(col => col.IdRol); //es primary
                tb.Property(col => col.IdRol)
                .UseIdentityColumn() //incremental (1,1)
                .ValueGeneratedOnAdd(); //no envies valor, la db lo gesyiona

                tb.Property(col => col.Nombre)
                .HasMaxLength(50)// maximo 50
                .IsRequired(); //no nulo
                tb.HasIndex(col => col.Nombre).IsUnique();// nombre unico

                tb.Property(col => col.Descripcion).HasMaxLength(100);

                tb.Property(col => col.Activo)
                .IsRequired()
                .HasDefaultValue(true);

                // ============================
                // SEED DE DATOS (ROLES INICIALES)
                // ============================
                tb.HasData(
                    new Rol
                    {
                        IdRol = 1,
                        Nombre = "Admin",
                        Descripcion = "Control completo del sistema",
                        Activo = true
                    },
                    new Rol
                    {
                        IdRol = 2,
                        Nombre = "Empleado",
                        Descripcion = "Gestión de libros y clientes",
                        Activo = true
                    },
                    new Rol
                    {
                        IdRol = 3,
                        Nombre = "Cliente",
                        Descripcion = "Rol lógico para filtro y sin acceso por el momento",
                        Activo = true
                    }
                );

            });

        }

    }
}
