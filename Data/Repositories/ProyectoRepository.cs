using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Repositories
{
    public class ProyectoRepository : IProyectoRepository
    {

        private readonly OrtganizaDbContext _db;
        public ProyectoRepository(OrtganizaDbContext db)
        {
            _db = db;
        }

        public void CargarLider(Guid proyectoId, Guid userId)
        {
            List<MiembroProyecto> lideresAnterior = _db.MiembroProyecto.Where(mp => mp.TipoRol == TipoRolProyecto.Lider && mp.ProyectoId == proyectoId).ToList();

            foreach (MiembroProyecto miembro in lideresAnterior)
            {
                miembro.TipoRol = TipoRolProyecto.Miembro;
            }

            MiembroProyecto miembroPromovido = _db.MiembroProyecto.Where(mp => mp.UserId == userId && mp.ProyectoId == proyectoId).FirstOrDefault();
            if (miembroPromovido == null)
            {
                _db.MiembroProyecto.Add(new MiembroProyecto
                {
                    ProyectoId = proyectoId,
                    UserId = userId,
                    Baja = false,
                    TipoRol = TipoRolProyecto.Lider
                });
            }
            else
            {
                miembroPromovido.TipoRol = TipoRolProyecto.Lider;
                _db.Update(miembroPromovido);
            }
            
            _db.SaveChanges();
        }

        public void CargarMiembros(Guid proyectoId, List<Guid> userIds)
        {
            if (userIds.Count > 0)
            {
                foreach (Guid userId in userIds)
                {
                    _db.MiembroProyecto.Add(new MiembroProyecto
                    {
                        ProyectoId = proyectoId,
                        UserId = userId,
                        Baja = false,
                        TipoRol = TipoRolProyecto.Miembro
                    });
                }

                _db.SaveChanges(true);
            }
        }

        public void ActualizarUsuarios(List<MiembroProyecto> miembros) {
            foreach (var miembro in miembros)
            {
                _db.Entry(miembro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            _db.SaveChanges();
        }

        public Guid CargarProyecto(Proyecto proyecto)
        {
            proyecto.FechaCreacion = DateTime.Now;
            _db.Proyectos.Add(proyecto);
            _db.SaveChanges();

            return proyecto.ProyectoId;
        }

        public Proyecto Get(Guid id)
        {
            return _db.Proyectos.Find(id);
        }

        public bool ExisteUsuario(Guid userId,Guid proyectoId)
        {
            return _db.MiembroProyecto.Any(mp => mp.UserId == userId && mp.ProyectoId == proyectoId);
        }

        public void Update(Proyecto proyecto)
        {
            _db.Entry(proyecto).State = EntityState.Modified;
            _db.SaveChanges(true);
        }

        public bool Existe(string nombre, Guid? proyectoId = null)
        {
            bool respuesta = false;
            if(proyectoId == null)
                respuesta = _db.Proyectos.Any(p => p.Nombre == nombre);
            else
                respuesta = _db.Proyectos.Any(p => p.Nombre == nombre && p.ProyectoId != proyectoId);
            return respuesta;
        }

        public List<MiembroProyecto> GetMiembrosByUserId(Guid userId)
        {
            return _db.MiembroProyecto
                   .Include(m => m.Proyecto)
                   .ThenInclude(p => p.Miembros)
                   .Include(m => m.Usuario)
                   .Where(m => m.UserId == userId)
                   .ToList();
        }

        public List<MiembroProyecto> GetMiembrosByProyectoId(Guid proyectoId, bool incluirBajas = false)
        {
            List<MiembroProyecto> miembros;
            if (incluirBajas)
            {
                miembros = _db.MiembroProyecto.Where(mp => mp.ProyectoId == proyectoId && mp.TipoRol == TipoRolProyecto.Miembro)
                           .Include(m => m.Proyecto)
                           .ThenInclude(p => p.Miembros)
                           .ThenInclude(m => m.Usuario)
                           .ToList();
            }
            else
            {
                miembros = _db.MiembroProyecto.Where(mp => mp.ProyectoId == proyectoId && mp.TipoRol == TipoRolProyecto.Miembro && mp.Baja == false)
                           .Include(m => m.Proyecto)
                           .ThenInclude(p => p.Miembros)
                           .ThenInclude(m => m.Usuario)
                           .ToList();
            }
            return miembros;
        }

        public List<MiembroProyecto> GetMiembrosParaActualizar(Guid proyectoId, bool incluirBajas = false)
        {
            var query = _db.MiembroProyecto
                           .Where(mp => mp.ProyectoId == proyectoId && mp.TipoRol == TipoRolProyecto.Miembro);

            if (!incluirBajas)
            {
                query = query.Where(mp => mp.Baja == false);
            }

            return query.ToList();
        }

        public MiembroProyecto GetLiderProyecto(Guid proyectoId)
        {
            return _db.MiembroProyecto.Where(mp => mp.ProyectoId == proyectoId && mp.TipoRol == TipoRolProyecto.Lider && !mp.Baja).FirstOrDefault();
        }

        public int GetMiembrosActivos(Guid proyectoId)
        {
            return _db.MiembroProyecto.Where(p => p.ProyectoId == proyectoId).Count();
        }
    }
}
