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
    /// Entidad para la tabla TareasTrace.
    /// </summary>
    public class TareaTrace
    {
        [Key]
        public Guid TareaTraceId { get; set; }
        public Guid TareaId { get; set; }
        public EstadoTarea EstadoCambiado { get; set; }
        [StringLength(500)]
        public string Comentarios { get; set; }

        [ForeignKey("TareaId")]
        public Tarea Tarea { get; set; }
    }
}
