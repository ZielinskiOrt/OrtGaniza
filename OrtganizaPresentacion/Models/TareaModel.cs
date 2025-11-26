using Business.DTO;
using Entities.Enums;

namespace OrtganizaPresentacion.Models
{
    public class TareaModel
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
