using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace Entities.Entities
{
    /// <summary>
    /// Entidad para la tabla Tareas.
    /// </summary>
    public class Tarea
    {
        [Key]
        public Guid TareaId { get; set; }
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public Prioridad Prioridad { get; set; }
        public int EstimacionDias { get; set; }
        public EstadoTarea Estado { get; set; }
        public bool Vencida { get; set; } = false;
        public bool Baja { get; set; } = false;
        public DateTime? FechaVencimiento { get; set; }
        public Guid ProyectoId { get; set; }

        [ForeignKey("ProyectoId")]
        public Proyecto Proyecto { get; set; }
        public ICollection<TareaColaborador> Colaboradores { get; set; } = new List<TareaColaborador>();
        public ICollection<TareaSolicitudBaja> SolicitudesBaja { get; set; } = new List<TareaSolicitudBaja>();
        public ICollection<TareaTrace> TareasTrace { get; set; } = new List<TareaTrace>();
    }
}
