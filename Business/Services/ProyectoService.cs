using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.CustomExceptions;
using Business.DTO;
using Business.Services.Interfaces;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Entities.Entities;

namespace Business.Services
{
    public class ProyectoService : IProyectoService
    {
        private readonly IMapper _mapper;
        private readonly IProyectoRepository _proyectoRepository;
        private const string MSG_ERROR_USUARIO_EXISTENTE = "Error usuario existente";
        private const string MSG_ERROR_USUARIO_Y_LIDER_EXISTENTE = "El lider no puede ser un usuario colaborador";
        private const string MSG_ERROR_PROYECTO_EXISTENTE = "Error ya existe un proyecto con el mismo nombre";
        public ProyectoService(IMapper mapper, IProyectoRepository proyectoRepository) 
        { 
            _mapper = mapper;
            _proyectoRepository = proyectoRepository;
        }
        public Guid CargarProyecto(ProyectoDTO proyectoDTO)
        {
            if (_proyectoRepository.Existe(proyectoDTO.Nombre))
            {
                throw new ProyectoException(MSG_ERROR_PROYECTO_EXISTENTE);
            } else if (proyectoDTO.MiembrosIds.Contains(proyectoDTO.UserId))
            {
                throw new ProyectoException(MSG_ERROR_USUARIO_Y_LIDER_EXISTENTE);
            }                
            Proyecto proyecto = _mapper.Map<Proyecto>(proyectoDTO);
            Guid proyectoId = _proyectoRepository.CargarProyecto(proyecto);

            foreach (Guid userId in proyectoDTO.MiembrosIds)
            {
                if (_proyectoRepository.ExisteUsuario(proyectoDTO.UserId,proyectoId))
                {
                    throw new ProyectoException(MSG_ERROR_USUARIO_EXISTENTE);
                }
            }
            _proyectoRepository.CargarMiembros(proyectoId,proyectoDTO.MiembrosIds);
            _proyectoRepository.CargarLider(proyectoId, proyectoDTO.UserId);
            return proyectoId;
        }

        public ProyectoDTO Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ProyectoResponseDTO> GetByUserID(Guid userId)
        {
            List<MiembroProyecto> miembros = _proyectoRepository.GetMiembrosByUserId(userId);

            List<ProyectoResponseDTO> proyectos = new List<ProyectoResponseDTO>();
            foreach (MiembroProyecto miembro in miembros)
            {
                ProyectoResponseDTO proyectoDTO = _mapper.Map<ProyectoResponseDTO>(miembro.Proyecto);
                proyectoDTO.NombrePropietario = miembro.Usuario.UserName;
                proyectoDTO.TipoRolProyecto = miembro.TipoRol;
                proyectoDTO.CantidadMiembros = miembro.Proyecto.Miembros.Count;

                proyectos.Add(proyectoDTO);
            }

            return proyectos;
        }

        public void Update(ProyectoDTO proyectoDTO)
        {
            throw new NotImplementedException();
        }
    }
}
