using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace Business.DTO
{
    public class MiembroProyectoDTO
    {
        public Guid ProyectoId { get; set; }
        public Guid UserId { get; set; }
        public bool Baja { get; set; } = false;
        public TipoRolProyecto TipoRol { get; set; }
    }
}
