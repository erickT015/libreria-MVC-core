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

                tb.Property(col => col.NombreCompleto).HasMaxLength(50);

                tb.Property(col => col.Correo).HasMaxLength(50);

                tb.Property(col => col.PasswordHash)
                .IsRequired() //no nulo
                .HasMaxLength(255); //tamaño de 255
            });

            modelBuilder.Entity<Empleado>().ToTable("Empleado"); //le asignamos el nombre, a la fuerza no por convencion
        }

    }
}
