using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrtganizaPresentacion.Models
{
    public class CrearTareaModel
    {
        public CrearTareaModel()
        {
            FechaInicio = DateTime.Today;
        }

        [Required(ErrorMessage = "El ID del Proyecto es requerido.")]
        public Guid ProyectoId { get; set; }

        [Required(ErrorMessage = "El título de la tarea es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres.")]
        [Display(Name = "Título de la Tarea")]
        public string Titulo { get; set; }

        [StringLength(1000, ErrorMessage = "La descripción no puede exceder los 1000 caracteres.")]
        [Required(ErrorMessage = "Se debe agregar una descripción")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La prioridad es obligatoria.")]
        [Display(Name = "Prioridad")]
        public Prioridad Prioridad { get; set; }

        [Required(ErrorMessage = "El tiempo estimado es obligatorio.")]
        [Range(1, 365, ErrorMessage = "El tiempo estimado debe ser entre 1 y 365 días.")]
        [Display(Name = "Tiempo Estimado (días)")]
        public int EstimacionDias { get; set; }

        public List<UsuarioModel> Usuarios { get; set; } = new List<UsuarioModel>();

        [Required(ErrorMessage = "Debe asignar al menos un responsable.")]
        [Display(Name = "Responsables")]
        public List<Guid> ResponsablesIds { get; set; }
    }
}
