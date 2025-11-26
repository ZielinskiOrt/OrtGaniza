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
using Entities.Enums;

namespace Business.Services
{
    public class TareaService : ITareaService
    {
        private readonly ITareaRepository _tareaRepository;
        private readonly IMapper _mapper;
        public  TareaService(ITareaRepository tareaRepository, IMapper mapper) { 
            this._tareaRepository = tareaRepository;
            this._mapper = mapper;
        }
        private const string MSG_ERROR_TAREA_EXISTENTE = "Error ya existe una tarea con el mismo nombre";
        public void CambiarEstado(Guid tareaId, EstadoTarea estadoNuevo)
        {
            _tareaRepository.CambiarEstado(tareaId, estadoNuevo);
        }

        public void CargarTarea(TareaDTO tareaDTO)
        {
            if (_tareaRepository.AnyByNombre(tareaDTO.Titulo))
            {
                throw new TareaException(MSG_ERROR_TAREA_EXISTENTE);
            }
            Guid tareaId = _tareaRepository.CargarTarea(_mapper.Map<Tarea>(tareaDTO));
            _tareaRepository.CargarMiembros(tareaDTO.ResponsablesIds,tareaId);
        }

        public List<TareaResponseDTO> GetTareasByProyectoId(Guid proyectoId)
        {
            List<TareaResponseDTO> tareas = _mapper.Map<List<TareaResponseDTO>>(_tareaRepository.GetAllByIdProyecto(proyectoId));
            foreach (TareaResponseDTO tarea in tareas)
            {
                tarea.Miembros = _mapper.Map<List<UsuarioDTO>>(_tareaRepository.GetMiembrosByTareaId(tarea.TareaId));
            }
            return tareas;
        }
    }
}
