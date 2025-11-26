using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class TareaRepository : ITareaRepository
    {

        private readonly OrtganizaDbContext _db;
        
        public TareaRepository(OrtganizaDbContext db)
        {
            _db = db;
        }
        public bool AnyByNombre(string nombreTarea)
        {
            return _db.Tareas.Any(t => t.Titulo == nombreTarea);
        }

        public void CambiarEstado(Guid tareaId, EstadoTarea estadoTarea)
        {
            Tarea tarea = _db.Tareas.Find(tareaId);
            if (tarea != null)
            {
                tarea.Estado = estadoTarea;
                _db.Entry(tarea).State = EntityState.Modified;
                _db.SaveChanges();
            }          
        }

        public void CargarMiembros(List<Guid> miembros, Guid tareaId)
        {
            foreach (Guid id in miembros)
            {
                _db.TareaColaborador.Add(new TareaColaborador
                {
                    Baja = false,
                    TareaId = tareaId,
                    UserId = id
                });
            }
            _db.SaveChanges();
        }

        public Guid CargarTarea(Tarea tarea)
        {
            tarea.Estado = EstadoTarea.Pendiente;
            _db.Tareas.Add(tarea);
            _db.SaveChanges();
            return tarea.TareaId; 
        }

        public List<Tarea> GetAllByIdProyecto(Guid proyectoId)
        {
            return _db.Tareas.Where(t => t.ProyectoId == proyectoId).Include(t => t.Colaboradores).ThenInclude(c => c.Usuario).ToList();
        }

        public List<Usuario> GetMiembrosByTareaId(Guid tareaId)
        {
            List<Usuario> usuarios = _db.Tareas
                    .Where(t => t.TareaId == tareaId)
                    .SelectMany(t => t.Colaboradores)
                    .Select(tc => tc.Usuario)
                    .ToList();

            return usuarios;
        }
    }
}
