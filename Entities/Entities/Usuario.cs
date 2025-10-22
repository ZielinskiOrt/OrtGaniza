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
    /// Entidad para la tabla Usuarios.
    /// </summary>
    public class Usuario
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string PassWord { get; set; }
        public DateTime? LastLogin { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public Guid WebRoleId { get; set; }

        [ForeignKey("WebRoleId")]
        public WebRole WebRole { get; set; }
        public ICollection<MiembroProyecto> ProyectosAsignados { get; set; } = new List<MiembroProyecto>();
        public ICollection<TareaColaborador> TareasComoColaborador { get; set; } = new List<TareaColaborador>();
        public ICollection<TareaSolicitudBaja> SolicitudesBaja { get; set; } = new List<TareaSolicitudBaja>();
    }
}
