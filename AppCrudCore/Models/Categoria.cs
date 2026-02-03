using System.ComponentModel.DataAnnotations;

namespace AppCrudCore.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "El nombre no puede superar los 30 caracteres")]
        public string Nombre { get; set; }

        public bool Activo { get; set; }
    }
}
