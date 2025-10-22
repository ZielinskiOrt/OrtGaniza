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

    }
}
