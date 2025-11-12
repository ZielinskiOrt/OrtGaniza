using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;
using Business.Services.Interfaces;
using Data.Repositories.Interfaces;

namespace Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuariosRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository) 
        { 
            this._usuariosRepository = usuarioRepository;
        }
        public UsuarioDTO Get(Guid id)
        {
            return null;
        }
    }
}
