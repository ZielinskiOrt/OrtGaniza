using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.CustomExceptions;
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
        private const string MSG_ERROR_INEXISTENTE = "Error el usuario ya existe";
        private const string MSG_ERROR_CREDENCIALES = "Error al ingresar credenciales";
        public UsuarioService(IUsuarioRepository usuarioRepository, IWebRoleRepository webRoleRepository, IMapper mapper) 
        {
            this._mapper = mapper;
            this._usuariosRepository = usuarioRepository;
            this._webRoleRepository = webRoleRepository;
        }
        public UsuarioDTO Get(Guid id)
        {
            return _mapper.Map<UsuarioDTO>(_usuariosRepository.Get(id));
        }
        public Guid CargarUsuario(UsuarioDTO usuarioDTO)
        {
            Guid id = Guid.Empty;
       
            if (!_usuariosRepository.Any(usuarioDTO.UserName, usuarioDTO.Email))
            {

                usuarioDTO.WebRoleId = _webRoleRepository.GetPerfilUsuarioBasico();
                usuarioDTO.LastLogin = DateTime.Now;

                Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);

                id = _usuariosRepository.Insert(usuario);
            }
            else
            {
                throw new UserException(MSG_ERROR_INEXISTENTE);
            }

            return id;
        }

        public List<UsuarioDTO> GetAll()
        {
            return _mapper.Map<List<UsuarioDTO>>(_usuariosRepository.GetAll());
        }

        public Guid Login(LoginDTO login)
        {
            Usuario result = _usuariosRepository.Login(login.UserId, login.Contrasena);
            if (result == null)
            {
                throw new UserException(MSG_ERROR_CREDENCIALES);
            }

            return result.UserId;
        }
    }
}
