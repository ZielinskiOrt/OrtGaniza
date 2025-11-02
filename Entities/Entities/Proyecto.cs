using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Entities.Entities
{
    /// <summary>
    /// Entidad para la tabla Proyectos.
    /// </summary>
    public class Proyecto
    {
        [Key]
        public Guid ProyectoId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<MiembroProyecto> Miembros { get; set; } = new List<MiembroProyecto>();
        public List<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}
