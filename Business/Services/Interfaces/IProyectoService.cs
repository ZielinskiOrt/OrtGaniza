using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;
using Entities.Entities;

namespace Business.Services.Interfaces
{
    public interface IProyectoService
    {
        Guid CargarProyecto(ProyectoDTO proyectoDTO);
        void Update(ProyectoDTO proyectoDTO);
        ProyectoDTO Get(Guid id);

        List<ProyectoResponseDTO> GetByUserID(Guid userId);

        List<MiembroProyectoDTO> GetMiembrosByProyectoId(Guid proyectoId);


    }
}
