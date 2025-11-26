using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace OrtganizaPresentacion.Models
{
    public class ProyectoModel
    {

        public Guid ProyectoId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(1, ErrorMessage = "Debe tener al menos 1 caracteres.")]
        [MaxLength(50, ErrorMessage = "Debe tener maximo 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        [MinLength(1, ErrorMessage = "Debe tener al menos 1 caracteres.")]
        [MaxLength(100, ErrorMessage = "Debe tener maximo 100 caracteres.")]
        public string Descripcion { get; set; }
        public Guid UserId { get; set; }
        public string NombrePropietario { get; set; }
        public int CantidadMiembros { get; set; }
        public TipoRolProyecto TipoRolProyecto { get; set; }

        public List<Guid> MiembrosIds { get; set; } = new List<Guid>();
    }
}
