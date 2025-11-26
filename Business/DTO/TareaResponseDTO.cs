using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace Business.DTO
{
    public class TareaResponseDTO
    {
        public Guid TareaId { get; set; }
        public Guid ProyectoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public Prioridad Prioridad { get; set; }

        public EstadoTarea Estado { get; set; }
        public int EstimacionDias { get; set; }

        public List<UsuarioDTO> Miembros { get; set; }
    }
}
