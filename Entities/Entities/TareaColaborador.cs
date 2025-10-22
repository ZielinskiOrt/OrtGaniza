using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    /// <summary>
    /// Entidad para la tabla TareaColaborador (relación N:M entre Usuario y Tarea).
    /// </summary>
    public class TareaColaborador
    {
        [Key]
        public Guid TareaColaboradorId { get; set; }

        public Guid TareaId { get; set; }
        public Guid UserId { get; set; }

        public bool Baja { get; set; } = false;

        [ForeignKey("TareaId")]
        public Tarea Tarea { get; set; }

        [ForeignKey("UserId")]
        public Usuario Usuario { get; set; }
    }
}
