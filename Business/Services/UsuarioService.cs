using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTO;
using Business.Services.Interfaces;
using Data.Repositories.Interfaces;
using Entities.Entities;

namespace Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuariosRepository;
        private readonly IWebRoleRepository _webRoleRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository usuarioRepository, IWebRoleRepository webRoleRepository, IMapper mapper) 
        {
            this._mapper = mapper;
            this._usuariosRepository = usuarioRepository;
            this._webRoleRepository = webRoleRepository;
        }
        public UsuarioDTO Get(Guid id)
        {
            return null;
        }
        public bool CargarUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {
                usuarioDTO.WebRoleId = _webRoleRepository.GetPerfilUsuarioBasico();
                usuarioDTO.LastLogin = DateTime.Now;

                Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);

                _usuariosRepository.Insert(usuario);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
