using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IWebRoleRepository
    {
        Guid GetPerfilUsuarioBasico();
        Guid GetPerfilUsuarioAdmin();

        Guid GetPerfil(string nombre);
    }
}
