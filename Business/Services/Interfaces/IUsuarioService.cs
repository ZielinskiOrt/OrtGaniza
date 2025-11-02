using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;

namespace Business.Services.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDTO Get(Guid id);
    }
}
