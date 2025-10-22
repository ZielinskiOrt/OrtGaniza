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
    /// Entidad para la tabla MiembrosProyectos (relación N:M entre Usuario y Proyecto).
    /// </summary>
    public class MiembroProyecto
    {
        [Key]
        public Guid MiembroProyectoId { get; set; }
        public Guid ProyectoId { get; set; }
        public Guid UserId { get; set; }
        public bool Baja { get; set; } = false;
        public TipoRolProyecto TipoRol { get; set; }

        [ForeignKey("ProyectoId")]
        public Proyecto Proyecto { get; set; }

        [ForeignKey("UserId")]
        public Usuario Usuario { get; set; }
    }
}
