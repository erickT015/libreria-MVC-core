using AppCrudCore.Data; //conexion a base de datos
using AppCrudCore.Models; // modelos
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BCrypt.Net;
using AppCrudCore.Models.ViewModels;


namespace AppCrudCore.Controllers
{


    public class EmpleadoController : Controller
    {

        private readonly AppDBContext _appDBContext;

        public EmpleadoController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }


        //RENDERIZAR LISTA
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            var lista = await _appDBContext.Empleados
                               .AsNoTracking() // solo lectura
                               .ToListAsync(); //enlistar items

            return View(lista);
        }


        //RENDERIZA FORMULARIO CREAR EMPLEADO
        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }


        //CREAR EMPLEADO
        [HttpPost]
        public async Task<IActionResult> Nuevo(Empleado empleado)
        {
            if (!ModelState.IsValid)
                return View(empleado);

            var Nuevoempleado = new Empleado
            {
                NombreCompleto = empleado.NombreCompleto,
                Correo = empleado.Correo,
                FechaContrato = empleado.FechaContrato,
                Activo = empleado.Activo,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(empleado.PasswordHash)
            };


            await _appDBContext.Empleados.AddAsync(Nuevoempleado); //guardar los datos en db
            await _appDBContext.SaveChangesAsync(); //actualizar

            return RedirectToAction(nameof(Lista)); //redirigir a la vista de lista
        }


        //RENDERIZAR EDITAR EMPLEADO
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var empleadoDb = await _appDBContext.Empleados
           .FirstOrDefaultAsync(e => e.IdEmpleado == id);

            if (empleadoDb == null)
                return NotFound();

            var empleado = new EmpleadoEditViewModel
            {
                IdEmpleado = empleadoDb.IdEmpleado,
                NombreCompleto = empleadoDb.NombreCompleto,
                Correo = empleadoDb.Correo,
                FechaContrato = empleadoDb.FechaContrato,
                Activo = empleadoDb.Activo

                // ❌ NO Password
                // ❌ NO PasswordHash
                // ❌ NO ConfirmarPass
            };

            return View(empleado); // ✅ AHORA SÍ
        }

        //EDITAR EMPLEADO
        [HttpPost]
        public async Task<IActionResult> Editar(EmpleadoEditViewModel empleado)
        {
            try
            {

                if (!ModelState.IsValid)
                    return View(empleado);

                // Buscar el empleado la base de datos
                var empleadoDb = await _appDBContext.Empleados
                    .FirstOrDefaultAsync(e => e.IdEmpleado == empleado.IdEmpleado);

                // Si no existe o id invalido
                if (empleadoDb == null)
                    return NotFound();

                //  Actualizar los campos con los nuevos datos
                empleadoDb.NombreCompleto = empleado.NombreCompleto;
                empleadoDb.Correo = empleado.Correo;
                empleadoDb.FechaContrato = empleado.FechaContrato;
                empleadoDb.Activo = empleado.Activo;

                // Solo entramos aquí si el usuario escribió algo
                if (!string.IsNullOrWhiteSpace(empleado.NuevaPass))
                {
                    //  Validar que ambas contraseñas coincidan
                    if (empleado.NuevaPass != empleado.ConfirmarPass)
                    {
                        // Mostramos en la vista el error
                        ModelState.AddModelError(
                            "ConfirmarPass",
                            "Las contraseñas no coinciden"
                        );

                        // Volvemos a la vista SIN tocar la contraseña anterior
                        return View(empleado);
                    }

                    //  Hashear contraseña
                    empleadoDb.PasswordHash =
                        BCrypt.Net.BCrypt.HashPassword(empleado.NuevaPass);
                }

                //  Guardar datos que fueron cambiados
                await _appDBContext.SaveChangesAsync();

                //redirigir a la vista de lista
                return RedirectToAction(nameof(Lista));
            }
            catch (Exception)
            {
                // Ocurrió un error
                ModelState.AddModelError(
                    "",
                    "Ocurrió un error al actualizar el empleado"
                );

                // Retornar vista con el mensaje de error
                return View(empleado);
            }
        }



        //CONSULTAR ELIMINAR USUARIO - NO USADO
        // Muestra la vista de confirmación
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            var empleado = await _appDBContext.Empleados
                                              .AsNoTracking() // solo lectura
                                              .FirstOrDefaultAsync(e => e.IdEmpleado == id);
            if (empleado == null)
                return NotFound();

            return View(empleado);
        }

        //BORRAR EMPLEADO
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            try
            {
                var empleado = await _appDBContext.Empleados.FindAsync(id);

                if (empleado == null)
                    return NotFound();

                _appDBContext.Empleados.Remove(empleado);
                await _appDBContext.SaveChangesAsync();

                return RedirectToAction(nameof(Lista));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Error al eliminar el empleado.");
                return RedirectToAction(nameof(Lista));
            }
        }
    }
}
