using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IProyectoRepository
    {
        bool Existe(string nombre, Guid? proyectoId);
        Guid CargarProyecto(Proyecto proyecto);
        void CargarMiembros(Guid proyectoId, List<Guid> userIds);
        void CargarLider(Guid proyectoId, Guid userId);
        void Update(Proyecto Proyecto);
        Proyecto Get(Guid id);
        bool ExisteUsuario(Guid userId, Guid proyectoId);
        List<MiembroProyecto> GetMiembrosByUserId(Guid userId);
        List<MiembroProyecto> GetMiembrosByProyectoId(Guid proyectoId, bool incluirBajas = false);
        void ActualizarUsuarios(List<MiembroProyecto> miembros);
        MiembroProyecto GetLiderProyecto(Guid proyectoId);
    }
}
