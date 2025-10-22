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
    /// Entidad para la tabla TareasSolicitudesBaja.
    /// </summary>
    public class TareaSolicitudBaja
    {
        [Key]
        public Guid TareaSolicitudBajaId { get; set; }
        public Guid TareaId { get; set; }
        public Guid UserId { get; set; }

        [StringLength(500)]
        public string Comentarios { get; set; }
        [ForeignKey("TareaId")]
        public Tarea Tarea { get; set; }

        [ForeignKey("UserId")]
        public Usuario Usuario { get; set; }
    }
}
