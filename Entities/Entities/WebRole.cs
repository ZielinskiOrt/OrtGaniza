using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    /// <summary>
    /// Entidad para la tabla WebRoles.
    /// </summary>
    public class WebRole
    {
        [Key]
        public Guid WebRoleId { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }

}
