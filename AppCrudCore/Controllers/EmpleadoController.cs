using AppCrudCore.Data; //conexion a base de datos
using AppCrudCore.Models; // modelos
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


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
            await _appDBContext.Empleados.AddAsync(empleado); //guardar los datos en db
            await _appDBContext.SaveChangesAsync(); //actualizar
            return RedirectToAction(nameof(Lista)); //redirigir a la vista de lista
        }


        //RENDERIZAR EDITAR EMPLEADO
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Empleado empleado = await _appDBContext.Empleados.FirstAsync(e => e.IdEmpleado == id);
            return View(empleado);
        }


        //EDITAR EMPLEADO
        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
             _appDBContext.Empleados.Update(empleado); //actualizar los datos en db
            await _appDBContext.SaveChangesAsync(); //guardar
            return RedirectToAction(nameof(Lista)); //redirigir a la vista de lista
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
