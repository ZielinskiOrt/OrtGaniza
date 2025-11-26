using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;
using Entities.Enums;

namespace Business.Services.Interfaces
{
    public interface ITareaService
    {
        void CargarTarea(TareaDTO tareaDTO);
        List<TareaResponseDTO> GetTareasByProyectoId(Guid proyectoId);
        void CambiarEstado(Guid tareaId, EstadoTarea estadoNuevo);
    }
}
