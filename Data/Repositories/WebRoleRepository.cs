using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.Repositories
{
    public class WebRoleRepository : IWebRoleRepository
    {


        private readonly OrtganizaDbContext _db;
        private readonly string ROL_BASICO = "Basico";
        private readonly string ROL_ADMIN = "Administrador";

        public WebRoleRepository(OrtganizaDbContext db)
        {
            _db = db;
        }
        public WebRoleRepository() { 
        }

        public Guid GetPerfilUsuarioAdmin()
        {
            return GetPerfil(ROL_ADMIN);
        }

        public Guid GetPerfilUsuarioBasico()
        {
            return GetPerfil(ROL_BASICO);
        }
        public Guid GetPerfil(string nombre)
        {
            return _db.WebRoles.Where(wr => wr.Descripcion == nombre).FirstOrDefault().WebRoleId;

        }
    }
}
