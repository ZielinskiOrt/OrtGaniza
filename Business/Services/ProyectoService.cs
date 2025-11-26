using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.CustomExceptions;
using Business.DTO;
using Business.Services.Interfaces;
using Business.Validators;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Entities.Entities;

namespace Business.Services
{
    public class ProyectoService : IProyectoService
    {
        private readonly IMapper _mapper;
        private readonly IProyectoRepository _proyectoRepository;
        private readonly IProyectoServiceValidator _validator;
        public ProyectoService(IMapper mapper, IProyectoRepository proyectoRepository, IProyectoServiceValidator validator) 
        { 
            _mapper = mapper;
            _proyectoRepository = proyectoRepository;
            _validator = validator;
        }
        public Guid CargarProyecto(ProyectoDTO proyectoDTO)
        {   
            _validator.CrearProyectoValidation(proyectoDTO);

            Proyecto proyecto = _mapper.Map<Proyecto>(proyectoDTO);
            Guid proyectoId = _proyectoRepository.CargarProyecto(proyecto);
            _proyectoRepository.CargarMiembros(proyectoId,proyectoDTO.MiembrosIds);
            _proyectoRepository.CargarLider(proyectoId, proyectoDTO.UserId);
            return proyectoId;
        }

        public ProyectoDTO Get(Guid id)
        {
            return _mapper.Map<ProyectoDTO>(_proyectoRepository.Get(id));
        }

        public List<ProyectoResponseDTO> GetByUserID(Guid userId)
        {
            List<MiembroProyecto> miembroProyectos = _proyectoRepository.GetMiembrosByUserId(userId);

            List<ProyectoResponseDTO> proyectos = new List<ProyectoResponseDTO>();
            foreach (MiembroProyecto miembroProyecto in miembroProyectos)
            {
                ProyectoResponseDTO proyectoDTO = _mapper.Map<ProyectoResponseDTO>(miembroProyecto.Proyecto);
                proyectoDTO.NombrePropietario = miembroProyecto.Usuario.UserName;
                proyectoDTO.TipoRolProyecto = miembroProyecto.TipoRol;
                proyectoDTO.CantidadMiembros = miembroProyecto.Proyecto.Miembros.Where(m => !m.Baja).Count();

                proyectos.Add(proyectoDTO);
            }

            return proyectos;
        }

        public void Update(ProyectoDTO proyectoDTO)
        {
            _validator.EditarProyectoValidation(proyectoDTO);
            List<Guid> miembrosNuevos = new List<Guid>(proyectoDTO.MiembrosIds);
            _proyectoRepository.CargarLider(proyectoDTO.ProyectoId, proyectoDTO.UserId);
            List<MiembroProyecto> miembrosActuales = _proyectoRepository.GetMiembrosParaActualizar(proyectoDTO.ProyectoId,true);
            foreach (MiembroProyecto miembro in miembrosActuales)
            {
                miembro.Baja = true;
                foreach (Guid id in proyectoDTO.MiembrosIds)
                {
                    if (miembro.UserId == id)
                    {
                        miembro.Baja = false;
                        miembrosNuevos.Remove(id);
                    }
                }
            }
            _proyectoRepository.ActualizarUsuarios(miembrosActuales);
            _proyectoRepository.CargarMiembros(proyectoDTO.ProyectoId, miembrosNuevos);
            _proyectoRepository.Update(_mapper.Map<Proyecto>(proyectoDTO));
        }

        public List<MiembroProyectoDTO> GetMiembrosByProyectoId(Guid proyectoId)
        {
            return _mapper.Map<List<MiembroProyectoDTO>>(_proyectoRepository.GetMiembrosByProyectoId(proyectoId));
        }

        public MiembroProyectoDTO GetLiderProyecto(Guid proyectoId)
        {
            return _mapper.Map<MiembroProyectoDTO>(_proyectoRepository.GetLiderProyecto(proyectoId));
        }
    }
}
