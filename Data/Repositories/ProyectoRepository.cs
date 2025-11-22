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
        private const string MSG_ERROR_MIEMBRO_EXISTENTE = "Error ya existe el usuario";
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
            _db.MiembroProyecto.Add(new MiembroProyecto
            {
                ProyectoId = proyectoId,
                UserId = userId,
                Baja = false,
                TipoRol = TipoRolProyecto.Lider
            });
            _db.SaveChanges();
        }

        public void CargarMiembros(Guid proyectoId, List<Guid> userIds)
        {
            foreach (Guid userId in userIds) {
                _db.MiembroProyecto.Add(new MiembroProyecto
                {
                    ProyectoId = proyectoId,
                    UserId = userId,
                    Baja = false,
                    TipoRol = TipoRolProyecto.Miembro
                });
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

        public void Update(Proyecto Proyecto)
        {
            throw new NotImplementedException();
        }

        public bool Existe(string nombre)
        {
            return _db.Proyectos.Any(p => p.Nombre == nombre);
        }

        public List<MiembroProyecto> GetMiembrosByUserId(Guid userId)
        {
            return _db.MiembroProyecto
                   .Include(m => m.Proyecto)
                   .Include(m => m.Usuario)
                   .Where(m => m.UserId == userId)
                   .ToList();
        }

    }
}
