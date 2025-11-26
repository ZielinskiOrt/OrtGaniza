using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using Entities.Enums;

namespace Data.Repositories.Interfaces
{
    public interface ITareaRepository
    {
        bool AnyByNombre(string nombreTarea);

        Guid CargarTarea(Tarea tarea);

        void CambiarEstado(Guid tareaId, EstadoTarea estadoTarea);

        void CargarMiembros(List<Guid> miembros, Guid tareaId);

        List<Tarea> GetAllByIdProyecto(Guid proyectoId);

        List<Usuario> GetMiembrosByTareaId(Guid tareaId);
    }
}
