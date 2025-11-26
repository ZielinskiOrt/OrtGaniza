using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace Business.DTO
{
    public class ProyectoResponseDTO
    {
        public Guid ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NombrePropietario { get; set; }

        public TipoRolProyecto TipoRolProyecto { get; set; }

        public int CantidadMiembros { get; set; }
    }
}
