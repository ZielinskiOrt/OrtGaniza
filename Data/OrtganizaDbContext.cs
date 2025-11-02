using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class OrtganizaDbContext: DbContext
    {
        public OrtganizaDbContext(DbContextOptions<OrtganizaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto> Proyectos { get; set; }

        public DbSet<WebRole> WebRoles { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<TareaColaborador> TareaColaborador { get; set; }

        public DbSet<TareaSolicitudBaja> TareaSolicitudBaja { get; set; }

        public DbSet<TareaTrace> TareaTrace { get; set; }

        public DbSet<MiembroProyecto> MiembroProyecto { get; set; }

    }
}
